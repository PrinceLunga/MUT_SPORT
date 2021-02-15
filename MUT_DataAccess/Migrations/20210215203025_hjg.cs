using Microsoft.EntityFrameworkCore.Migrations;

namespace MUT_DataAccess.Migrations
{
    public partial class hjg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Residences",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "ResName",
                table: "Residences");

            migrationBuilder.AddColumn<int>(
                name: "ResId",
                table: "Residences",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Residences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Residences",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isInMainCamp",
                table: "Residences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residences",
                table: "Residences",
                column: "ResId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Residences",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "ResId",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "isInMainCamp",
                table: "Residences");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Residences",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Residences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResName",
                table: "Residences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residences",
                table: "Residences",
                column: "Id");
        }
    }
}
