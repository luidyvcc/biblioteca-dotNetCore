using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjBiblioteca.Migrations
{
    public partial class ApplicationUserUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Usuario");
        }
    }
}
