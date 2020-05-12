using Microsoft.EntityFrameworkCore.Migrations;

namespace Demokratianweb.Migrations
{
    public partial class addTrazabilidad2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "voto_ronda");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "votante");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "votacion_votante");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "votacion_candidato");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ronda_candidato");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "candidato");

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "voto_ronda",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "votante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "votacion_votante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "votacion_candidato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "votacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "ronda_votacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "ronda_candidato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "control_voto_votante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "candidato",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "voto_ronda");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "votante");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "votacion_votante");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "votacion_candidato");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "votacion");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "ronda_votacion");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "ronda_candidato");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "control_voto_votante");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "candidato");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "voto_ronda",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "votante",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "votacion_votante",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "votacion_candidato",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "ronda_candidato",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "control_voto_votante",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "candidato",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
