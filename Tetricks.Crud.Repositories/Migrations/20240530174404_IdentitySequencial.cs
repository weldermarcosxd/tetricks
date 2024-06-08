using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tetricks.Crud.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class IdentitySequencial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tarefa_Sequencial",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Sequencial",
                table: "Produto");

            migrationBuilder.AlterColumn<long>(
                name: "Sequencial",
                table: "Tarefa",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Sequencial",
                table: "Produto",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_Sequencial",
                table: "Tarefa",
                column: "Sequencial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Sequencial",
                table: "Produto",
                column: "Sequencial",
                unique: true);
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

            migrationBuilder.AlterColumn<long>(
                name: "Sequencial",
                table: "Tarefa",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Sequencial",
                table: "Produto",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_Sequencial",
                table: "Tarefa",
                column: "Sequencial");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Sequencial",
                table: "Produto",
                column: "Sequencial");
        }
    }
}
