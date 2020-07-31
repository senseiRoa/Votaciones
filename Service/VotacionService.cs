using Demokratianweb.Data;
using Demokratianweb.Data.Entities;
using Demokratianweb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Demokratianweb.Data.Enums.HelpConstantes;

namespace Demokratianweb.Service
{
    public class VotacionService
    {
        private ApplicationDbContext _applicationDBContext;
        public VotacionService(ApplicationDbContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }
        public Boolean AddVotacion(VotacionWrapper entityWrappper)
        {
            var registro = false;
            try
            {

                using (var transaction = this._applicationDBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var estado = DateTime.Compare(DateTime.Now, entityWrappper.Votacion.fechaInicial) >= 0 && DateTime.Compare(DateTime.Now, entityWrappper.Votacion.fechaFinal) <= 0 ? EstadoVotacion.Abierta : EstadoVotacion.Cerrada;
                        var entity = new VotacionEntity
                        {
                            fechaCreacion = DateTime.Now,
                            fechaEdicion = DateTime.Now,
                            Id = Guid.NewGuid(),
                            EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                            Estado = estado,
                            Descripcion = entityWrappper.Votacion.Descripcion,
                            Nombre = entityWrappper.Votacion.Nombre,
                            fechaFinal = entityWrappper.Votacion.fechaFinal,
                            fechaInicial = entityWrappper.Votacion.fechaInicial
                        };

                        var validation = validateEntity(entity);

                        if (!validation)
                        {
                            throw new Exception("Datos incompletos para registrar la Votación");
                        }


                        var votantes = (from v in entityWrappper.Votantes
                                        select new VotacionVotanteEntity
                                        {
                                            Id = Guid.NewGuid(),
                                            IdVotacion = entity.Id,
                                            IdVotante = Guid.Parse(v),
                                            ///////////////////////////////////////
                                            EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                                            fechaCreacion = DateTime.Now,
                                            fechaEdicion = DateTime.Now,

                                        }
                                      ).ToList();

                        var candidatos = (from c in entityWrappper.Candidatos
                                          select new VotacionCandidatoEntity
                                          {
                                              Id = Guid.NewGuid(),
                                              IdVotacion = entity.Id,
                                              IdCandidato = Guid.Parse(c),
                                              ///////////////////////////////////////
                                              EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                                              fechaCreacion = DateTime.Now,
                                              fechaEdicion = DateTime.Now,


                                          }
                                     ).ToList();

                        this._applicationDBContext.Add(entity);
                        this._applicationDBContext.AddRange(votantes);
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
        public List<VotacionCandidatoEntity> GetAllCandidatosByVotacionId(Guid votacionId)
        {


            var result = (from c in this._applicationDBContext.Set<VotacionCandidatoEntity>()
                          where c.IdVotacion.Equals(votacionId)
                          orderby c.Candidato.Nombre
                          select c
                        ).Include(i => i.Candidato)
                        .ToList();

            return result;

        }
        public List<VotacionVotanteEntity> GetAllVotantesByVotacionId(Guid votacionId)
        {


            var result = (from v in this._applicationDBContext.Set<VotacionVotanteEntity>()
                          where v.IdVotacion.Equals(votacionId)
                          orderby v.Votante.Nombre
                          select v
                        ).Include(i => i.Votante)
                        .ToList();

            return result;

        }

        public List<RondaVotacionEntity> GetAllRondas(Guid votacionId)
        {


            var result = (from r in this._applicationDBContext.Set<RondaVotacionEntity>()
                          where r.IdVotacion.Equals(votacionId)
                          && r.fechaEliminacion == null && !r.Estado.Equals(EstadoRondaVotacion.Anulada)
                          orderby r.fechaCreacion descending
                          select r
                        ).ToList();

            return result;

        }


        public int UpdateStatus()
        {


            var now = DateTime.Now;

            var result = (from v in this._applicationDBContext.Set<VotacionEntity>()
                          where v.fechaEliminacion == null && v.Estado.Equals(EstadoVotacion.Abierta)
                && !(now >= v.fechaInicial && now <= v.fechaFinal)
                          select v).ToList();

            if (result.Count > 0)
            {

                result.ForEach(v => v.Estado = EstadoVotacion.Cerrada);
                //actualizo en base de datos

                this._applicationDBContext.UpdateRange(result);
                this._applicationDBContext.SaveChanges();
            }


            var result2 = (from v in this._applicationDBContext.Set<VotacionEntity>()
                           where v.fechaEliminacion == null && v.Estado.Equals(EstadoVotacion.Cerrada)
                 && now >= v.fechaInicial && now <= v.fechaFinal
                           select v).ToList();

            if (result2.Count > 0)
            {

                result2.ForEach(v => v.Estado = EstadoVotacion.Abierta);
                //actualizo en base de datos

                this._applicationDBContext.UpdateRange(result2);
                this._applicationDBContext.SaveChanges();
            }



            return result.Count;

        }

        public Boolean validateEntity(VotacionEntity entity)
        {
            return
                            DateTime.Compare(entity.fechaInicial, entity.fechaFinal) <= 0 &&
                            !string.IsNullOrEmpty(entity.Nombre) &&
                            !string.IsNullOrEmpty(entity.Descripcion);
        }
    }
}
