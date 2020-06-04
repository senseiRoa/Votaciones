﻿// <auto-generated />
using System;
using Demokratianweb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Demokratianweb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200604032506_migracion03062020cambioEsquema")]
    partial class migracion03062020cambioEsquema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Demokratianweb.Data.Entities.CandidatoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("urlImage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("candidato");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.ControlVotoVotanteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdRondaVotacion")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdRondaVotante")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdRondaVotacion");

                    b.HasIndex("IdRondaVotante");

                    b.ToTable("control_voto_votante");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.RondaCandidatoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdRondaVotacion")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdVotacionCandidato")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdRondaVotacion");

                    b.HasIndex("IdVotacionCandidato");

                    b.ToTable("ronda_candidato");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.RondaVotacionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdVotacion")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdVotacion");

                    b.ToTable("ronda_votacion");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.RondaVotanteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdRondaVotacion")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdVotacionVotante")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdRondaVotacion");

                    b.HasIndex("IdVotacionVotante");

                    b.ToTable("ronda_votante");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.VotacionCandidatoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdCandidato")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdVotacion")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdCandidato");

                    b.HasIndex("IdVotacion");

                    b.ToTable("votacion_candidato");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.VotacionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaFinal")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaInicial")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("votacion");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.VotacionVotanteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdVotacion")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdVotante")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdVotacion");

                    b.HasIndex("IdVotante");

                    b.ToTable("votacion_votante");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.VotanteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Correo")
                        .HasColumnType("text");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("RolId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("votante");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.VotoRondaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("EstadoRegistro")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdRondaVotacion")
                        .HasColumnType("uuid");

                    b.Property<string>("_hash")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("idRondaCandidato")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdRondaVotacion");

                    b.HasIndex("idRondaCandidato");

                    b.ToTable("voto_ronda");
                });

            modelBuilder.Entity("Demokratianweb.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("character varying(50000)")
                        .HasMaxLength(50000);

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SubjectId")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("character varying(50000)")
                        .HasMaxLength(50000);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SubjectId")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Key");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.ControlVotoVotanteEntity", b =>
                {
                    b.HasOne("Demokratianweb.Data.Entities.RondaVotacionEntity", "RondaVotacion")
                        .WithMany()
                        .HasForeignKey("IdRondaVotacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demokratianweb.Data.Entities.RondaVotanteEntity", "RondaVotante")
                        .WithMany()
                        .HasForeignKey("IdRondaVotante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.RondaCandidatoEntity", b =>
                {
                    b.HasOne("Demokratianweb.Data.Entities.RondaVotacionEntity", "RondaVotacion")
                        .WithMany()
                        .HasForeignKey("IdRondaVotacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demokratianweb.Data.Entities.VotacionCandidatoEntity", "VotacionCandidato")
                        .WithMany()
                        .HasForeignKey("IdVotacionCandidato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.RondaVotacionEntity", b =>
                {
                    b.HasOne("Demokratianweb.Data.Entities.VotacionEntity", "Votacion")
                        .WithMany()
                        .HasForeignKey("IdVotacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.RondaVotanteEntity", b =>
                {
                    b.HasOne("Demokratianweb.Data.Entities.RondaVotacionEntity", "RondaVotacion")
                        .WithMany()
                        .HasForeignKey("IdRondaVotacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demokratianweb.Data.Entities.VotacionVotanteEntity", "VotacionVotante")
                        .WithMany()
                        .HasForeignKey("IdVotacionVotante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.VotacionCandidatoEntity", b =>
                {
                    b.HasOne("Demokratianweb.Data.Entities.CandidatoEntity", "Candidato")
                        .WithMany()
                        .HasForeignKey("IdCandidato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demokratianweb.Data.Entities.VotacionEntity", "Votacion")
                        .WithMany()
                        .HasForeignKey("IdVotacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.VotacionVotanteEntity", b =>
                {
                    b.HasOne("Demokratianweb.Data.Entities.VotacionEntity", "Votacion")
                        .WithMany()
                        .HasForeignKey("IdVotacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demokratianweb.Data.Entities.VotanteEntity", "Votante")
                        .WithMany()
                        .HasForeignKey("IdVotante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Demokratianweb.Data.Entities.VotoRondaEntity", b =>
                {
                    b.HasOne("Demokratianweb.Data.Entities.RondaVotacionEntity", "RondaVotacion")
                        .WithMany()
                        .HasForeignKey("IdRondaVotacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demokratianweb.Data.Entities.RondaCandidatoEntity", "RondaCandidato")
                        .WithMany()
                        .HasForeignKey("idRondaCandidato");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Demokratianweb.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Demokratianweb.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demokratianweb.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Demokratianweb.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
