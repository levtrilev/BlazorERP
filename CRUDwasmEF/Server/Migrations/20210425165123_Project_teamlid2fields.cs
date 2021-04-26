using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDwasmEF.Server.Migrations
{
    public partial class Project_teamlid2fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamlidFirstName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamlidLastName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamlidFirstName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamlidLastName",
                table: "Projects");
        }
    }
}
