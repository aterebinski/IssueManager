using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueManager.Migrations
{
    public partial class ChangeJobmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Checked",
                schema: "db",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checked",
                schema: "db",
                table: "Jobs");
        }
    }
}
