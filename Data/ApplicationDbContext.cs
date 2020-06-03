using Demokratianweb.Data.Entities;
using Demokratianweb.Data.Maps;
using Demokratianweb.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<VotacionEntity> VotacionEntities { get; set; }
        public DbSet<RondaVotacionEntity> RondaVotacionEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("uuid-ossp");
            new CandidatoMap(modelBuilder.Entity<CandidatoEntity>());
            new ControlVotoVotanteMap(modelBuilder.Entity<ControlVotoVotanteEntity>());
            new RondaVotanteMap(modelBuilder.Entity<RondaVotanteEntity>());
            new RondaCandidatoMap(modelBuilder.Entity<RondaCandidatoEntity>());
            new RondaVotacionMap(modelBuilder.Entity<RondaVotacionEntity>());
            new VotacionCandidatoMap(modelBuilder.Entity<VotacionCandidatoEntity>());
            new VotacionMap(modelBuilder.Entity<VotacionEntity>());
            new VotacionVotanteMap(modelBuilder.Entity<VotacionVotanteEntity>());
            new VotanteMap(modelBuilder.Entity<VotanteEntity>());
            new VotoRondaMap(modelBuilder.Entity<VotoRondaEntity>());



        }
    }
}
