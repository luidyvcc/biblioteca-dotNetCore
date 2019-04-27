using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjBiblioteca.Migrations
{
    public partial class AlterTableLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Livro",
                maxLength: 200,
                nullable: false,
                defaultValue: ""
                // oldClrType: typeof(int)
                );

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Livro",
                nullable: false,
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Livro");

            migrationBuilder.AlterColumn<int>(
                name: "Titulo",
                table: "Livro",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
