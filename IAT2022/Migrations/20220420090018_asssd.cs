using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAT2022.Migrations
{
    public partial class asssd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectPocoId",
                table: "ProjectTags",
                type: "INTEGER",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
