using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demokratianweb.Migrations
{
    public partial class migracion03062020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ronda_votante",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    EstadoRegistro = table.Column<int>(nullable: false),
                    fechaCreacion = table.Column<DateTime>(nullable: false),
                    fechaEdicion = table.Column<DateTime>(nullable: false),
                    fechaEliminacion = table.Column<DateTime>(nullable: true),
                    IdRondaVotacion = table.Column<Guid>(nullable: false),
                    IdVotacionVotante = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ronda_votante", x => x.id);
                    table.ForeignKey(
                        name: "FK_ronda_votante_ronda_votacion_IdRondaVotacion",
                        column: x => x.IdRondaVotacion,
                        principalTable: "ronda_votacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ronda_votante_votacion_votante_IdVotacionVotante",
                        column: x => x.IdVotacionVotante,
                        principalTable: "votacion_votante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ronda_votante_IdRondaVotacion",
                table: "ronda_votante",
                column: "IdRondaVotacion");

            migrationBuilder.CreateIndex(
                name: "IX_ronda_votante_IdVotacionVotante",
                table: "ronda_votante",
                column: "IdVotacionVotante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ronda_votante");
        }
    }
}
