using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueManager.Migrations
{
    public partial class AddColorConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EntityGroups_ColorId",
                schema: "db",
                table: "EntityGroups",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityGroups_EntityGroupColor_ColorId",
                schema: "db",
                table: "EntityGroups",
                column: "ColorId",
                principalSchema: "db",
                principalTable: "EntityGroupColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityGroups_EntityGroupColor_ColorId",
                schema: "db",
                table: "EntityGroups");

            migrationBuilder.DropIndex(
                name: "IX_EntityGroups_ColorId",
                schema: "db",
                table: "EntityGroups");
        }
    }
}
