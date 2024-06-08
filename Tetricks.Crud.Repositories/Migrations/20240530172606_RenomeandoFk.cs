using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tetricks.Crud.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RenomeandoFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuario_Id",
                table: "Produto");

            migrationBuilder.AddColumn<Guid>(
                name: "AtualizadoPorId",
                table: "Produto",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_AtualizadoPorId",
                table: "Produto",
                column: "AtualizadoPorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuario_AtualizadoPorId",
                table: "Produto",
                column: "AtualizadoPorId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuario_AtualizadoPorId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_AtualizadoPorId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "AtualizadoPorId",
                table: "Produto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuario_Id",
                table: "Produto",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
