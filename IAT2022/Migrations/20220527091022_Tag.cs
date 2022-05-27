using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAT2022.Migrations
{
    public partial class Tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTags_Projects_ProjectPocoId",
                table: "ProjectTags");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTags_ProjectPocoId",
                table: "ProjectTags");

            migrationBuilder.DropColumn(
                name: "ProjectPocoId",
                table: "ProjectTags");

            migrationBuilder.CreateTable(
                name: "TagPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPocoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPoco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagPoco_Projects_ProjectPocoId",
                        column: x => x.ProjectPocoId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagPoco_ProjectPocoId",
                table: "TagPoco",
                column: "ProjectPocoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagPoco");

            migrationBuilder.AddColumn<int>(
                name: "ProjectPocoId",
                table: "ProjectTags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_ProjectPocoId",
                table: "ProjectTags",
                column: "ProjectPocoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTags_Projects_ProjectPocoId",
                table: "ProjectTags",
                column: "ProjectPocoId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
