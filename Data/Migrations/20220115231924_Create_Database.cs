using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Create_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Churrasco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataRealizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValorArrecadado = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    ValorSugerido = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    ValorSugeridoBebida = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    Ativo = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churrasco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Ativo = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChurrascoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ChurrascoId = table.Column<int>(type: "int", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", maxLength: 150, nullable: false),
                    ValorPagoBebida = table.Column<decimal>(type: "decimal(18,2)", maxLength: 150, nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", maxLength: 150, nullable: false),
                    PresencaConfirmada = table.Column<int>(type: "int", maxLength: 150, nullable: false),
                    DataConfirmacao = table.Column<DateTime>(type: "datetime2", maxLength: 150, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurrascoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChurrascoUsuario_Churrasco_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "Churrasco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChurrascoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChurrascoUsuario_ChurrascoId",
                table: "ChurrascoUsuario",
                column: "ChurrascoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChurrascoUsuario_UsuarioId",
                table: "ChurrascoUsuario",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChurrascoUsuario");

            migrationBuilder.DropTable(
                name: "Churrasco");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
