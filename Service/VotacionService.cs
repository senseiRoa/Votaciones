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
    public class VotacionService
    {
        private ApplicationDbContext _applicationDBContext;
        public VotacionService(ApplicationDbContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }
        public Boolean AddVotacion(VotacionWrapper entity)
        {
            var registro = false;
            try
            {

                using (var transaction = this._applicationDBContext.Database.BeginTransaction())
                {
                    try
                    {

                        entity.Votacion.fechaCreacion = DateTime.Now;
                        entity.Votacion.fechaEdicion = DateTime.Now;
                        entity.Votacion.Id = Guid.NewGuid();
                        entity.Votacion.EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo;
                        entity.Votacion.Estado = Data.Enums.HelpConstantes.EstadoVotacion.Abierta;
                        var votantes = (from v in entity.Votantes
                                        select new VotacionVotanteEntity
                                        {
                                            Id = Guid.NewGuid(),
                                            IdVotacion = entity.Votacion.Id,
                                            IdVotante = Guid.Parse(v),
                                            ///////////////////////////////////////
                                            EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                                            fechaCreacion = DateTime.Now,
                                            fechaEdicion = DateTime.Now,

                                        }
                                      ).ToList();

                        var candidatos = (from c in entity.Candidatos
                                          select new VotacionCandidatoEntity
                                          {
                                              Id = Guid.NewGuid(),
                                              IdVotacion = entity.Votacion.Id,
                                              IdCandidato = Guid.Parse(c),
                                              ///////////////////////////////////////
                                              EstadoRegistro = Data.Enums.HelpConstantes.EstadoRegistro.Activo,
                                              fechaCreacion = DateTime.Now,
                                              fechaEdicion = DateTime.Now,


                                          }
                                     ).ToList();

                        this._applicationDBContext.Add(entity.Votacion);
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
                          select c
                        ).Include(i => i.Candidato)
                        .ToList();

            return result;

        }
        public List<VotacionVotanteEntity> GetAllVotantesByVotacionId(Guid votacionId)
        {


            var result = (from v in this._applicationDBContext.Set<VotacionVotanteEntity>()
                          where v.IdVotacion.Equals(votacionId)
                          select v
                        ).Include(i => i.Votante)
                        .ToList();

            return result;

        }
    }
}
