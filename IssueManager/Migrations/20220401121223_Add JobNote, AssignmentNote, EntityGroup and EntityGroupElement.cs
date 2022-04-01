using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueManager.Migrations
{
    public partial class AddJobNoteAssignmentNoteEntityGroupandEntityGroupElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                schema: "db",
                table: "Jobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                schema: "db",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryNextId",
                schema: "db",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryPreviousId",
                schema: "db",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDateTime",
                schema: "db",
                table: "Jobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifyUserId",
                schema: "db",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                schema: "db",
                table: "Assignments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                schema: "db",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryNextId",
                schema: "db",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryPreviousId",
                schema: "db",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDateTime",
                schema: "db",
                table: "Assignments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifyUserId",
                schema: "db",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "db",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AssignmentNotes",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Del = table.Column<bool>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    ModifyDateTime = table.Column<DateTime>(nullable: false),
                    ModifyUserId = table.Column<int>(nullable: false),
                    HistoryPreviousId = table.Column<int>(nullable: false),
                    HistoryNextId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityGroupElements",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(nullable: false),
                    EntityGroupId = table.Column<int>(nullable: false),
                    Del = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    ModifyDateTime = table.Column<DateTime>(nullable: false),
                    ModifyUserId = table.Column<int>(nullable: false),
                    HistoryPreviousId = table.Column<int>(nullable: false),
                    HistoryNextId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityGroupElements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityGroups",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobNotes",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Del = table.Column<bool>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    ModifyDateTime = table.Column<DateTime>(nullable: false),
                    ModifyUserId = table.Column<int>(nullable: false),
                    HistoryPreviousId = table.Column<int>(nullable: false),
                    HistoryNextId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobNotes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentNotes",
                schema: "db");

            migrationBuilder.DropTable(
                name: "EntityGroupElements",
                schema: "db");

            migrationBuilder.DropTable(
                name: "EntityGroups",
                schema: "db");

            migrationBuilder.DropTable(
                name: "JobNotes",
                schema: "db");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "db",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                schema: "db",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "HistoryNextId",
                schema: "db",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "HistoryPreviousId",
                schema: "db",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifyDateTime",
                schema: "db",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                schema: "db",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "db",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                schema: "db",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "HistoryNextId",
                schema: "db",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "HistoryPreviousId",
                schema: "db",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ModifyDateTime",
                schema: "db",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                schema: "db",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "db",
                table: "Assignments");
        }
    }
}
