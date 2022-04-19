using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueManager.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                schema: "db",
                table: "EntityGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                schema: "db",
                table: "EntityGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryNextId",
                schema: "db",
                table: "EntityGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryPreviousId",
                schema: "db",
                table: "EntityGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDateTime",
                schema: "db",
                table: "EntityGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifyUserId",
                schema: "db",
                table: "EntityGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                schema: "db",
                table: "Entities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                schema: "db",
                table: "Entities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryNextId",
                schema: "db",
                table: "Entities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryPreviousId",
                schema: "db",
                table: "Entities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDateTime",
                schema: "db",
                table: "Entities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifyUserId",
                schema: "db",
                table: "Entities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EntityGroupElements_EntityGroupId",
                schema: "db",
                table: "EntityGroupElements",
                column: "EntityGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityGroupElements_EntityId",
                schema: "db",
                table: "EntityGroupElements",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityGroupElements_Entities_EntityId",
                schema: "db",
                table: "EntityGroupElements",
                column: "EntityId",
                principalSchema: "db",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityGroupElements_EntityGroups_EntityGroupId",
                schema: "db",
                table: "EntityGroupElements",
                column: "EntityGroupId",
                principalSchema: "db",
                principalTable: "EntityGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityGroupElements_Entities_EntityId",
                schema: "db",
                table: "EntityGroupElements");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityGroupElements_EntityGroups_EntityGroupId",
                schema: "db",
                table: "EntityGroupElements");

            migrationBuilder.DropIndex(
                name: "IX_EntityGroupElements_EntityGroupId",
                schema: "db",
                table: "EntityGroupElements");

            migrationBuilder.DropIndex(
                name: "IX_EntityGroupElements_EntityId",
                schema: "db",
                table: "EntityGroupElements");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "db",
                table: "EntityGroups");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                schema: "db",
                table: "EntityGroups");

            migrationBuilder.DropColumn(
                name: "HistoryNextId",
                schema: "db",
                table: "EntityGroups");

            migrationBuilder.DropColumn(
                name: "HistoryPreviousId",
                schema: "db",
                table: "EntityGroups");

            migrationBuilder.DropColumn(
                name: "ModifyDateTime",
                schema: "db",
                table: "EntityGroups");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                schema: "db",
                table: "EntityGroups");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "db",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                schema: "db",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "HistoryNextId",
                schema: "db",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "HistoryPreviousId",
                schema: "db",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "ModifyDateTime",
                schema: "db",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                schema: "db",
                table: "Entities");
        }
    }
}
