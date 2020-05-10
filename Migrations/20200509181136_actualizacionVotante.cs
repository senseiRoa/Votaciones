using Microsoft.EntityFrameworkCore.Migrations;

namespace Demokratianweb.Migrations
{
    public partial class actualizacionVotante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RolId",
                table: "votante",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "votante",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RolId",
                table: "votante");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "votante");
        }
    }
}
