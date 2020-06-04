using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demokratianweb.Migrations
{
    public partial class migracion03062020cambioEsquema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_control_voto_votante_votacion_votante_IdVotacionVotante",
                table: "control_voto_votante");

            migrationBuilder.DropIndex(
                name: "IX_control_voto_votante_IdVotacionVotante",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "IdVotacionVotante",
                table: "control_voto_votante");

            migrationBuilder.AddColumn<Guid>(
                name: "IdRondaVotante",
                table: "control_voto_votante",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "urlImage",
                table: "candidato",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_control_voto_votante_IdRondaVotante",
                table: "control_voto_votante",
                column: "IdRondaVotante");

            migrationBuilder.AddForeignKey(
                name: "FK_control_voto_votante_ronda_votante_IdRondaVotante",
                table: "control_voto_votante",
                column: "IdRondaVotante",
                principalTable: "ronda_votante",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_control_voto_votante_ronda_votante_IdRondaVotante",
                table: "control_voto_votante");

            migrationBuilder.DropIndex(
                name: "IX_control_voto_votante_IdRondaVotante",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "IdRondaVotante",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "urlImage",
                table: "candidato");

            migrationBuilder.AddColumn<Guid>(
                name: "IdVotacionVotante",
                table: "control_voto_votante",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_control_voto_votante_IdVotacionVotante",
                table: "control_voto_votante",
                column: "IdVotacionVotante");

            migrationBuilder.AddForeignKey(
                name: "FK_control_voto_votante_votacion_votante_IdVotacionVotante",
                table: "control_voto_votante",
                column: "IdVotacionVotante",
                principalTable: "votacion_votante",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
