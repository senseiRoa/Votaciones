using Demokratianweb.Data;
using Demokratianweb.Data.Entities;
using Demokratianweb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Demokratianweb.Service
{
    public class RondaVotacionService
    {
        private ApplicationDbContext _applicationDBContext;
        public RondaVotacionService(ApplicationDbContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }
        public Boolean AddRondaVotacion(RondaVotacionWrapper entity)
        {
            var registro = false;
            try
            {

                using (var transaction = this._applicationDBContext.Database.BeginTransaction())
                {
                    try
                    {

                        entity.Rondavotacion.fechaCreacion = DateTime.Now;
                        entity.Rondavotacion.fechaEdicion = DateTime.Now;
                        entity.Rondavotacion.Id = Guid.NewGuid();
                        entity.Rondavotacion.EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo;
                        entity.Rondavotacion.Estado = Data.Enums.HelpConstantes.EstadoRondaVotacion.Abierta;


                        var candidatos = (from c in entity.Candidatos
                                          select new RondaCandidatoEntity
                                          {
                                              Id = Guid.NewGuid(),
                                              IdRondaVotacion = entity.Rondavotacion.Id,
                                              IdVotacionCandidato = Guid.Parse(c),
                                              ///////////////////////////////////////
                                              EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                                              fechaCreacion = DateTime.Now,
                                              fechaEdicion = DateTime.Now,


                                          }
                                     ).ToList();

                        this._applicationDBContext.Add(entity.Rondavotacion);
                        this._applicationDBContext.AddRange(candidatos);


                        this._applicationDBContext.SaveChanges();


                        transaction.Commit();
                        registro = true;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("hubo un error guardando el registro=>" + ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return registro;
        }

        public List<RondaCandidatoEntity> GetAllCandidatosByRondaId(Guid rondaId)
        {


            var result = (from c in this._applicationDBContext.Set<RondaCandidatoEntity>()
                          where c.IdRondaVotacion.Equals(rondaId)
                          select c
                        )
                        .Include(i => i.VotacionCandidato)
                        .Include(i => i.VotacionCandidato.Candidato)
                        .ToList();

            return result;

        }

        internal Boolean AddVoto(VotoWrapper entity, Guid userId)
        {
            var registro = false;
            try
            {

                using (var transaction = this._applicationDBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var rondaVotacion = this._applicationDBContext.Set<RondaVotacionEntity>()
                            .Where(i => i.Id.Equals(entity.RondaId))
                            .FirstOrDefault();

                        var votante = (from x in this._applicationDBContext.Set<VotanteEntity>()
                                       join vv in this._applicationDBContext.Set<VotacionVotanteEntity>() on x.Id equals vv.IdVotante
                                       where vv.IdVotacion.Equals(rondaVotacion.IdVotacion) && x.UserId.Equals(userId)
                                       select vv
                                     ).FirstOrDefault();
                        if (votante != null)
                        {


                            var continuar =
                            this._applicationDBContext.Set<ControlVotoVotanteEntity>().Where(i => i.IdRondaVotacion.Equals(entity.RondaId) && i.IdVotacionVotante.Equals(votante.Id)).Count();

                            if (continuar == 0)
                            {
                                var voto = new VotoRondaEntity()
                                {
                                    Id = Guid.NewGuid(),
                                    IdRondaVotacion = entity.RondaId,
                                    idRondaCandidato = entity.CandidatoId,

                                    ///////////////////////////////////////
                                    EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                                    fechaCreacion = DateTime.Now,
                                    fechaEdicion = DateTime.Now,
                                };

                                var controlVoto = new ControlVotoVotanteEntity()
                                {
                                    Id = Guid.NewGuid(),
                                    IdRondaVotacion = entity.RondaId,
                                    IdVotacionVotante = userId,

                                    ///////////////////////////////////////
                                    EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                                    fechaCreacion = DateTime.Now,
                                    fechaEdicion = DateTime.Now
                                };



                                this._applicationDBContext.Add(voto);
                                this._applicationDBContext.Add(controlVoto);

                                this._applicationDBContext.SaveChanges();


                                transaction.Commit();
                                registro = true;
                            }
                            else
                            {
                                throw new Exception("Ya voto");
                            }
                        }
                        else
                        {
                            throw new Exception("No tiene permisos para votar");
                        }

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("hubo un error guardando el registro=>" + ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return registro;
        }
    }
}
