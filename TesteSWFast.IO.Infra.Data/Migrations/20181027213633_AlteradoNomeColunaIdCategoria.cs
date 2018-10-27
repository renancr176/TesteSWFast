using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSWFast.IO.Infra.Data.Migrations
{
    public partial class AlteradoNomeColunaIdCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_IdCategory",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Produtos",
                newName: "IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_IdCategory",
                table: "Produtos",
                newName: "IX_Produtos_IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Produtos",
                newName: "IdCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                newName: "IX_Produtos_IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_IdCategory",
                table: "Produtos",
                column: "IdCategory",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
