using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneOrdini.EF.Migrations
{
    public partial class FixError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDCustomer",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDCustomer",
                table: "Orders");
        }
    }
}
