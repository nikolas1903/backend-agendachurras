using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Alter_Table_Churrasco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorArrecadado",
                table: "Churrasco",
                type: "decimal(18,2)",
                maxLength: 50,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorArrecadado",
                table: "Churrasco",
                type: "decimal(18,2)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 50,
                oldDefaultValue: 0m);
        }
    }
}
