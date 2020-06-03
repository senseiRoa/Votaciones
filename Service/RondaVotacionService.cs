using Demokratianweb.Data;
using Demokratianweb.Data.Entities;
using Demokratianweb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                        var votantes = (from vv in entity.Votantes
                                        select new RondaVotanteEntity
                                        {
                                            Id = Guid.NewGuid(),
                                            IdRondaVotacion = entity.Rondavotacion.Id,
                                            IdVotacionVotante = Guid.Parse(vv),
                                            ///////////////////////////////////////
                                            EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                                            fechaCreacion = DateTime.Now,
                                            fechaEdicion = DateTime.Now,


                                        }
                                     ).ToList();


                        this._applicationDBContext.Add(entity.Rondavotacion);
                        this._applicationDBContext.AddRange(candidatos);
                        this._applicationDBContext.AddRange(votantes);


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
                          orderby c.VotacionCandidato.Candidato.Nombre
                          select c
                        )
                        .Include(i => i.VotacionCandidato)
                        .Include(i => i.VotacionCandidato.Candidato)
                        .ToList();

            return result;

        }

        public List<RondaVotanteEntity> GetAllVotantesByRondaId(Guid rondaId)
        {


            var result = (from rv in this._applicationDBContext.Set<RondaVotanteEntity>()
                          join v in this._applicationDBContext.Set<VotacionVotanteEntity>()
                          on rv.IdVotacionVotante equals v.Id
                          where rv.IdRondaVotacion.Equals(rondaId)
                          orderby v.Votante.Nombre
                          select rv
                        )
                        .Include(i => i.VotacionVotante)
                        .Include(i => i.VotacionVotante.Votante)
                        .ToList();

            return result;

        }

        public List<RondaVotanteEntity> GetAllmissingVotersByRondaId(Guid rondaId)
        {
            //https://stackoverflow.com/questions/16166151/join-subquery-result-in-linq
            //https://stackoverflow.com/questions/33961414/left-join-on-two-lists-and-maintain-one-property-from-the-right-with-linq

            var result = (from rv in this._applicationDBContext.Set<RondaVotanteEntity>()
                          join v in this._applicationDBContext.Set<ControlVotoVotanteEntity>()
                          on rv.IdVotacionVotante equals v.IdVotacionVotante

                          into joinedList
                          from sub in joinedList.DefaultIfEmpty()
                          where rv.IdRondaVotacion.Equals(rondaId)
                          orderby rv.VotacionVotante.Votante.Nombre
                          select rv
                        )
                        .Include(i => i.VotacionVotante)
                        .Include(i => i.VotacionVotante.Votante)
                        .ToList();

            return result;

        }

        public Boolean AddVoto(VotoWrapper entity, Guid userId)
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
                                       join rv in this._applicationDBContext.Set<RondaVotanteEntity>() on vv.Id equals rv.IdVotacionVotante
                                       where vv.IdVotacion.Equals(rondaVotacion.IdVotacion) && x.UserId.ToLower().Equals(userId.ToString().ToLower())
                                       select vv
                                     ).FirstOrDefault();
                        if (votante != null)
                        {


                            var continuar =
                            this._applicationDBContext.Set<ControlVotoVotanteEntity>()
                            .Where(i => i.IdRondaVotacion.Equals(entity.RondaId) && i.IdVotacionVotante.Equals(votante.Id))
                            .Count();

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
                                    IdVotacionVotante = votante.Id,

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
                                throw new Exception("Usted Ya completó su voto");
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
                        throw new Exception(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return registro;
        }


        public ResultadoRonda Result(Guid rondaId)
        {
            ResultadoRonda resultado = new ResultadoRonda();
            try
            {
                var candidatosRonda = (from c in this._applicationDBContext.Set<RondaCandidatoEntity>()
                                       where c.IdRondaVotacion.Equals(rondaId)
                                       select new { id = c.Id, candidato = c.VotacionCandidato.Candidato.Nombre }
                                       )
                                       .Distinct()
                                       .ToList();
                candidatosRonda.Add(new { id = Guid.Empty, candidato = "Voto en Blanco" });
                var votos = (from vr in this._applicationDBContext.Set<VotoRondaEntity>()
                             where vr.IdRondaVotacion.Equals(rondaId)
                             select new { idCandidato = vr.idRondaCandidato }
                            ).ToList();


                int total = 0;
                foreach (var item in candidatosRonda)
                {
                    if (item.id.Equals(Guid.Empty))
                    {
                        total = votos.Where(i => i.idCandidato == null).Count();
                    }
                    else
                    {
                        total = votos.Where(i => i.idCandidato.Equals(item.id)).Count();
                    }

                    resultado.Candidatos.Add(item.candidato);
                    resultado.Votos.Add(total);


                }
                resultado.TotalVotos = resultado.Votos.Sum();

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
