using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDwasmEF.Server.Migrations
{
    public partial class Project_teamlidId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Developers_TeamlidId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "TeamlidId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Developers_TeamlidId",
                table: "Projects",
                column: "TeamlidId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Developers_TeamlidId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "TeamlidId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Developers_TeamlidId",
                table: "Projects",
                column: "TeamlidId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
