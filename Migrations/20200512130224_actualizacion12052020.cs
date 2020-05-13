using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demokratianweb.Migrations
{
    public partial class actualizacion12052020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_votacion_candidato_candidato_VotanteId",
                table: "votacion_candidato");

            migrationBuilder.DropForeignKey(
                name: "FK_voto_ronda_ronda_candidato_idRondaCandidato",
                table: "voto_ronda");

            migrationBuilder.DropIndex(
                name: "IX_votacion_candidato_VotanteId",
                table: "votacion_candidato");

            migrationBuilder.DropColumn(
                name: "VotanteId",
                table: "votacion_candidato");

            migrationBuilder.AlterColumn<Guid>(
                name: "idRondaCandidato",
                table: "voto_ronda",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "IdRondaVotacion",
                table: "voto_ronda",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_voto_ronda_IdRondaVotacion",
                table: "voto_ronda",
                column: "IdRondaVotacion");

            migrationBuilder.CreateIndex(
                name: "IX_votacion_candidato_IdCandidato",
                table: "votacion_candidato",
                column: "IdCandidato");

            migrationBuilder.AddForeignKey(
                name: "FK_votacion_candidato_candidato_IdCandidato",
                table: "votacion_candidato",
                column: "IdCandidato",
                principalTable: "candidato",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_voto_ronda_ronda_votacion_IdRondaVotacion",
                table: "voto_ronda",
                column: "IdRondaVotacion",
                principalTable: "ronda_votacion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_voto_ronda_ronda_candidato_idRondaCandidato",
                table: "voto_ronda",
                column: "idRondaCandidato",
                principalTable: "ronda_candidato",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_votacion_candidato_candidato_IdCandidato",
                table: "votacion_candidato");

            migrationBuilder.DropForeignKey(
                name: "FK_voto_ronda_ronda_votacion_IdRondaVotacion",
                table: "voto_ronda");

            migrationBuilder.DropForeignKey(
                name: "FK_voto_ronda_ronda_candidato_idRondaCandidato",
                table: "voto_ronda");

            migrationBuilder.DropIndex(
                name: "IX_voto_ronda_IdRondaVotacion",
                table: "voto_ronda");

            migrationBuilder.DropIndex(
                name: "IX_votacion_candidato_IdCandidato",
                table: "votacion_candidato");

            migrationBuilder.DropColumn(
                name: "IdRondaVotacion",
                table: "voto_ronda");

            migrationBuilder.AlterColumn<Guid>(
                name: "idRondaCandidato",
                table: "voto_ronda",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VotanteId",
                table: "votacion_candidato",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_votacion_candidato_VotanteId",
                table: "votacion_candidato",
                column: "VotanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_votacion_candidato_candidato_VotanteId",
                table: "votacion_candidato",
                column: "VotanteId",
                principalTable: "candidato",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_voto_ronda_ronda_candidato_idRondaCandidato",
                table: "voto_ronda",
                column: "idRondaCandidato",
                principalTable: "ronda_candidato",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
