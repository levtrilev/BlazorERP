using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDwasmEF.Server.Migrations
{
    public partial class Developer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Developers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Experience",
                table: "Developers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Developers",
                newName: "Name");
        }
    }
}
