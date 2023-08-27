using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Web.Migrations
{
    public partial class AtualizandoColunaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereço",
                table: "Advogados",
                newName: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Advogados",
                newName: "Endereço");
        }
    }
}
