using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tetricks.Crud.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Sequencial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Tarefa",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Produto",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_Sequencial",
                table: "Tarefa",
                column: "Sequencial");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Sequencial",
                table: "Produto",
                column: "Sequencial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tarefa_Sequencial",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Sequencial",
                table: "Produto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Tarefa",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Produto",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
