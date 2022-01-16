using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Change_Types_ChurrascoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPagoBebida",
                table: "ChurrascoUsuario",
                type: "decimal(18,2)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "ChurrascoUsuario",
                type: "decimal(18,2)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "ChurrascoUsuario",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "ChurrascoUsuario",
                type: "datetime2",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConfirmacao",
                table: "ChurrascoUsuario",
                type: "datetime2",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 150);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPagoBebida",
                table: "ChurrascoUsuario",
                type: "decimal(18,2)",
                maxLength: 150,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "ChurrascoUsuario",
                type: "decimal(18,2)",
                maxLength: 150,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "ChurrascoUsuario",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "ChurrascoUsuario",
                type: "datetime2",
                maxLength: 150,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConfirmacao",
                table: "ChurrascoUsuario",
                type: "datetime2",
                maxLength: 150,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
