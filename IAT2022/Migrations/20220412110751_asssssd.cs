using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAT2022.Migrations
{
    public partial class asssssd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    K1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    K2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    K3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    K4 = table.Column<bool>(type: "INTEGER", nullable: false),
                    K5 = table.Column<bool>(type: "INTEGER", nullable: false),
                    K6 = table.Column<bool>(type: "INTEGER", nullable: false),
                    K7 = table.Column<bool>(type: "INTEGER", nullable: false),
                    K8 = table.Column<bool>(type: "INTEGER", nullable: false),
                    K9 = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPoco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Owner = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Product = table.Column<int>(type: "INTEGER", nullable: true),
                    IPR = table.Column<int>(type: "INTEGER", nullable: true),
                    Team = table.Column<int>(type: "INTEGER", nullable: true),
                    Buissness = table.Column<int>(type: "INTEGER", nullable: true),
                    Finance = table.Column<int>(type: "INTEGER", nullable: true),
                    ProjectType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_CustomerPoco_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerPoco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectPocoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPoco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPoco_Projects_ProjectPocoId",
                        column: x => x.ProjectPocoId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentPoco_ProjectPocoId",
                table: "CommentPoco",
                column: "ProjectPocoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentPoco");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "CustomerPoco");
        }
    }
}
