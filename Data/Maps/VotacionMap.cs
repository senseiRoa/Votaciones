using Demokratianweb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data.Maps
{
    public class VotacionMap
    {
        public VotacionMap(EntityTypeBuilder<VotacionEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("votacion");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }
    public class RondaVotacionMap
    {
        public RondaVotacionMap(EntityTypeBuilder<RondaVotacionEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("ronda_votacion");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }
    public class CandidatoMap
    {
        public CandidatoMap(EntityTypeBuilder<CandidatoEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("candidato");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }
    public class ControlVotoVotanteMap
    {
        public ControlVotoVotanteMap(EntityTypeBuilder<ControlVotoVotanteEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("control_voto_votante");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }

     public class RondaCandidatoMap
    {
        public RondaCandidatoMap(EntityTypeBuilder<RondaCandidatoEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("ronda_candidato");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }

     public class VotacionCandidatoMap
    {
        public VotacionCandidatoMap(EntityTypeBuilder<VotacionCandidatoEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("votacion_candidato");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }

     public class VotacionVotanteMap
    {
        public VotacionVotanteMap(EntityTypeBuilder<VotacionVotanteEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("votacion_votante");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }

     public class VotanteMap
    {
        public VotanteMap(EntityTypeBuilder<VotanteEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("votante");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }

     public class VotoRondaMap
    {
        public VotoRondaMap(EntityTypeBuilder<VotoRondaEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("voto_ronda");
            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        }

    }





}
