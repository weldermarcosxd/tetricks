using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tetricks.Crud.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class usuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Descricao",
                table: "Usuario",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Id",
                table: "Usuario",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_Descricao",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Id",
                table: "Usuario");
        }
    }
}
