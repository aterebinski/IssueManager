using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueManager.Migrations
{
    public partial class AddEntityGroupColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                schema: "db",
                table: "EntityGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EntityGroupColor",
                schema: "db",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HEX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityGroupColor", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "EntityGroupColor",
                schema: "db");

            migrationBuilder.DropIndex(
                name: "IX_EntityGroups_ColorId",
                schema: "db",
                table: "EntityGroups");

            migrationBuilder.DropColumn(
                name: "ColorId",
                schema: "db",
                table: "EntityGroups");
        }
    }
}
