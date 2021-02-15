using Microsoft.EntityFrameworkCore.Migrations;

namespace MUT_DataAccess.Migrations
{
    public partial class Iniial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "StudentSports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentSportId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentSportId",
                table: "Sports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSports_SportId",
                table: "StudentSports",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSports_StudentId1",
                table: "StudentSports",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSports_Sports_SportId",
                table: "StudentSports",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSports_Students_StudentId1",
                table: "StudentSports",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSports_Sports_SportId",
                table: "StudentSports");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSports_Students_StudentId1",
                table: "StudentSports");

            migrationBuilder.DropIndex(
                name: "IX_StudentSports_SportId",
                table: "StudentSports");

            migrationBuilder.DropIndex(
                name: "IX_StudentSports_StudentId1",
                table: "StudentSports");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentSports");

            migrationBuilder.DropColumn(
                name: "StudentSportId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentSportId",
                table: "Sports");
        }
    }
}
