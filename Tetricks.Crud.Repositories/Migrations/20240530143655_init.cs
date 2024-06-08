using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tetricks.Crud.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Sequencial = table.Column<long>(type: "bigint", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    CriadoPorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_CriadoPorId",
                        column: x => x.CriadoPorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Sequencial = table.Column<long>(type: "bigint", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    CriadoPorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AtualizadoPorId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Completa = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuario_AtualizadoPorId",
                        column: x => x.AtualizadoPorId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuario_CriadoPorId",
                        column: x => x.CriadoPorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CriadoPorId",
                table: "Produto",
                column: "CriadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Descricao_TenantId",
                table: "Produto",
                columns: new[] { "Descricao", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_AtualizadoPorId",
                table: "Tarefa",
                column: "AtualizadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CriadoPorId",
                table: "Tarefa",
                column: "CriadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_Descricao_TenantId",
                table: "Tarefa",
                columns: new[] { "Descricao", "TenantId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
