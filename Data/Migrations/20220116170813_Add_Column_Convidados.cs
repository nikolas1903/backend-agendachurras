using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Add_Column_Convidados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Convidados",
                table: "Churrasco",
                type: "int",
                maxLength: 4,
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConvidadosConfirmados",
                table: "Churrasco",
                type: "int",
                maxLength: 4,
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Convidados",
                table: "Churrasco");

            migrationBuilder.DropColumn(
                name: "ConvidadosConfirmados",
                table: "Churrasco");
        }
    }
}
