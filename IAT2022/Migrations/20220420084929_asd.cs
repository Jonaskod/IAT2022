using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAT2022.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    K1 = table.Column<string>(type: "TEXT", nullable: true),
                    K2 = table.Column<string>(type: "TEXT", nullable: true),
                    K3 = table.Column<string>(type: "TEXT", nullable: true),
                    K4 = table.Column<string>(type: "TEXT", nullable: true),
                    K5a = table.Column<string>(type: "TEXT", nullable: true),
                    K5b = table.Column<string>(type: "TEXT", nullable: true),
                    K6a = table.Column<string>(type: "TEXT", nullable: true),
                    K6b = table.Column<string>(type: "TEXT", nullable: true),
                    K7a = table.Column<string>(type: "TEXT", nullable: true),
                    K7b = table.Column<string>(type: "TEXT", nullable: true),
                    K8a = table.Column<string>(type: "TEXT", nullable: true),
                    K8b = table.Column<string>(type: "TEXT", nullable: true),
                    K9 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerValue",
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
                    table.PrimaryKey("PK_CustomerValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagsBool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tag1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tag2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tag3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tag4 = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tag5 = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsBoolPoco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    K1TEST = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Owner = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Product = table.Column<int>(type: "INTEGER", nullable: true),
                    IPR = table.Column<int>(type: "INTEGER", nullable: true),
                    Team = table.Column<int>(type: "INTEGER", nullable: true),
                    Buissness = table.Column<int>(type: "INTEGER", nullable: true),
                    Finance = table.Column<int>(type: "INTEGER", nullable: true),
                    ProjectType = table.Column<string>(type: "TEXT", nullable: true),
                    TagsBoolId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_CustomerValue_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_TagsBoolPoco_TagsBoolId",
                        column: x => x.TagsBoolId,
                        principalTable: "TagsBool",
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

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TagsBoolId",
                table: "Projects",
                column: "TagsBoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentPoco");

            migrationBuilder.DropTable(
                name: "CustomerQuestions");

            migrationBuilder.DropTable(
                name: "ProjectTags");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "CustomerValue");

            migrationBuilder.DropTable(
                name: "TagsBool");
        }
    }
}
