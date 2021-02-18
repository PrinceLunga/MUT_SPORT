using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MUT_DataAccess.Migrations
{
    public partial class AddedDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDelete",
                table: "StudentSports");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StudentSports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ResidenceId",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerAchievements",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Coaches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Coaches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Coaches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Students_ResidenceId",
                table: "Students",
                column: "ResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAchievements_AchievementId",
                table: "PlayerAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAchievements_PlayerId",
                table: "PlayerAchievements",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerAchievements_Achievements_AchievementId",
                table: "PlayerAchievements",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerAchievements_TeamPlayers_PlayerId",
                table: "PlayerAchievements",
                column: "PlayerId",
                principalTable: "TeamPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Residences_ResidenceId",
                table: "Students",
                column: "ResidenceId",
                principalTable: "Residences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerAchievements_Achievements_AchievementId",
                table: "PlayerAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerAchievements_TeamPlayers_PlayerId",
                table: "PlayerAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Residences_ResidenceId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ResidenceId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_PlayerAchievements_AchievementId",
                table: "PlayerAchievements");

            migrationBuilder.DropIndex(
                name: "IX_PlayerAchievements_PlayerId",
                table: "PlayerAchievements");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StudentSports");

            migrationBuilder.DropColumn(
                name: "ResidenceId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Coaches");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelete",
                table: "StudentSports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "PlayerAchievements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
