using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demokratianweb.Migrations
{
    public partial class addTrazabilidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "voto_ronda",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "voto_ronda",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "voto_ronda",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "voto_ronda",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "votante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "votante",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "votante",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "votante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "votacion_votante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "votacion_votante",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "votacion_votante",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "votacion_votante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "votacion_candidato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "votacion_candidato",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "votacion_candidato",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "votacion_candidato",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "votacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "votacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "votacion",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "ronda_votacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "ronda_votacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "ronda_votacion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "ronda_candidato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "ronda_candidato",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "ronda_candidato",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "ronda_candidato",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "control_voto_votante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "control_voto_votante",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "control_voto_votante",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "control_voto_votante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "candidato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "candidato",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "candidato",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "candidato",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "voto_ronda");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "voto_ronda");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "voto_ronda");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "voto_ronda");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "votante");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "votante");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "votante");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "votante");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "votacion_votante");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "votacion_votante");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "votacion_votante");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "votacion_votante");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "votacion_candidato");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "votacion_candidato");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "votacion_candidato");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "votacion_candidato");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "votacion");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "votacion");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "votacion");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "ronda_votacion");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "ronda_votacion");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "ronda_votacion");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ronda_candidato");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "ronda_candidato");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "ronda_candidato");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "ronda_candidato");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "candidato");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "candidato");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "candidato");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "candidato");
        }
    }
}
