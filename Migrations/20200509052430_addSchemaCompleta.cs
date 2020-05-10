using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demokratianweb.Migrations
{
    public partial class addSchemaCompleta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "ronda_votacion");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "votacion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "votacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaFinal",
                table: "votacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaInicial",
                table: "votacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ronda_votacion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "ronda_votacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "candidato",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "votante",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Nombre = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "votacion_candidato",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdVotacion = table.Column<Guid>(nullable: false),
                    IdCandidato = table.Column<Guid>(nullable: false),
                    VotanteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votacion_candidato", x => x.id);
                    table.ForeignKey(
                        name: "FK_votacion_candidato_votacion_IdVotacion",
                        column: x => x.IdVotacion,
                        principalTable: "votacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_votacion_candidato_candidato_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "candidato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "votacion_votante",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdVotacion = table.Column<Guid>(nullable: false),
                    IdVotante = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votacion_votante", x => x.id);
                    table.ForeignKey(
                        name: "FK_votacion_votante_votacion_IdVotacion",
                        column: x => x.IdVotacion,
                        principalTable: "votacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_votacion_votante_votante_IdVotante",
                        column: x => x.IdVotante,
                        principalTable: "votante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ronda_candidato",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdRondaVotacion = table.Column<Guid>(nullable: false),
                    IdVotacionCandidato = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ronda_candidato", x => x.id);
                    table.ForeignKey(
                        name: "FK_ronda_candidato_ronda_votacion_IdRondaVotacion",
                        column: x => x.IdRondaVotacion,
                        principalTable: "ronda_votacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ronda_candidato_votacion_candidato_IdVotacionCandidato",
                        column: x => x.IdVotacionCandidato,
                        principalTable: "votacion_candidato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "control_voto_votante",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdRondaVotacion = table.Column<Guid>(nullable: false),
                    IdVotacionVotante = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_control_voto_votante", x => x.id);
                    table.ForeignKey(
                        name: "FK_control_voto_votante_ronda_votacion_IdRondaVotacion",
                        column: x => x.IdRondaVotacion,
                        principalTable: "ronda_votacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_control_voto_votante_votacion_votante_IdVotacionVotante",
                        column: x => x.IdVotacionVotante,
                        principalTable: "votacion_votante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "voto_ronda",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    _hash = table.Column<string>(nullable: true),
                    idRondaCandidato = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voto_ronda", x => x.id);
                    table.ForeignKey(
                        name: "FK_voto_ronda_ronda_candidato_idRondaCandidato",
                        column: x => x.idRondaCandidato,
                        principalTable: "ronda_candidato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_control_voto_votante_IdRondaVotacion",
                table: "control_voto_votante",
                column: "IdRondaVotacion");

            migrationBuilder.CreateIndex(
                name: "IX_control_voto_votante_IdVotacionVotante",
                table: "control_voto_votante",
                column: "IdVotacionVotante");

            migrationBuilder.CreateIndex(
                name: "IX_ronda_candidato_IdRondaVotacion",
                table: "ronda_candidato",
                column: "IdRondaVotacion");

            migrationBuilder.CreateIndex(
                name: "IX_ronda_candidato_IdVotacionCandidato",
                table: "ronda_candidato",
                column: "IdVotacionCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_votacion_candidato_IdVotacion",
                table: "votacion_candidato",
                column: "IdVotacion");

            migrationBuilder.CreateIndex(
                name: "IX_votacion_candidato_VotanteId",
                table: "votacion_candidato",
                column: "VotanteId");

            migrationBuilder.CreateIndex(
                name: "IX_votacion_votante_IdVotacion",
                table: "votacion_votante",
                column: "IdVotacion");

            migrationBuilder.CreateIndex(
                name: "IX_votacion_votante_IdVotante",
                table: "votacion_votante",
                column: "IdVotante");

            migrationBuilder.CreateIndex(
                name: "IX_voto_ronda_idRondaCandidato",
                table: "voto_ronda",
                column: "idRondaCandidato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "control_voto_votante");

            migrationBuilder.DropTable(
                name: "voto_ronda");

            migrationBuilder.DropTable(
                name: "votacion_votante");

            migrationBuilder.DropTable(
                name: "ronda_candidato");

            migrationBuilder.DropTable(
                name: "votante");

            migrationBuilder.DropTable(
                name: "votacion_candidato");

            migrationBuilder.DropTable(
                name: "candidato");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "votacion");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "votacion");

            migrationBuilder.DropColumn(
                name: "fechaFinal",
                table: "votacion");

            migrationBuilder.DropColumn(
                name: "fechaInicial",
                table: "votacion");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ronda_votacion");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ronda_votacion");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "ronda_votacion",
                type: "text",
                nullable: true);
        }
    }
}
