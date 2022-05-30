using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAT2022.Migrations
{
    public partial class adasdff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BuisnessQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuisnessQuestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerQuestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinanceQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceQuestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IPRQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPRQuestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Owner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamQuestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BusinessPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectPocoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPoco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPoco_Projects_ProjectPocoId",
                        column: x => x.ProjectPocoId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectPocoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerValue_Projects_ProjectPocoId",
                        column: x => x.ProjectPocoId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancePoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectPocoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancePoco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancePoco_Projects_ProjectPocoId",
                        column: x => x.ProjectPocoId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IPRPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectPocoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPRPoco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPRPoco_Projects_ProjectPocoId",
                        column: x => x.ProjectPocoId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectPocoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPoco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPoco_Projects_ProjectPocoId",
                        column: x => x.ProjectPocoId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TagPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamPoco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectPocoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPoco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamPoco_Projects_ProjectPocoId",
                        column: x => x.ProjectPocoId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPoco_ProjectPocoId",
                table: "BusinessPoco",
                column: "ProjectPocoId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerValue_ProjectPocoId",
                table: "CustomerValue",
                column: "ProjectPocoId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancePoco_ProjectPocoId",
                table: "FinancePoco",
                column: "ProjectPocoId");

            migrationBuilder.CreateIndex(
                name: "IX_IPRPoco_ProjectPocoId",
                table: "IPRPoco",
                column: "ProjectPocoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPoco_ProjectPocoId",
                table: "ProductPoco",
                column: "ProjectPocoId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPoco_ProjectPocoId",
                table: "TagPoco",
                column: "ProjectPocoId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPoco_ProjectPocoId",
                table: "TeamPoco",
                column: "ProjectPocoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuisnessQuestions");

            migrationBuilder.DropTable(
                name: "BusinessPoco");

            migrationBuilder.DropTable(
                name: "CustomerQuestions");

            migrationBuilder.DropTable(
                name: "CustomerValue");

            migrationBuilder.DropTable(
                name: "FinancePoco");

            migrationBuilder.DropTable(
                name: "FinanceQuestions");

            migrationBuilder.DropTable(
                name: "IPRPoco");

            migrationBuilder.DropTable(
                name: "IPRQuestions");

            migrationBuilder.DropTable(
                name: "ProductPoco");

            migrationBuilder.DropTable(
                name: "ProductQuestions");

            migrationBuilder.DropTable(
                name: "ProjectTags");

            migrationBuilder.DropTable(
                name: "TagPoco");

            migrationBuilder.DropTable(
                name: "TeamPoco");

            migrationBuilder.DropTable(
                name: "TeamQuestions");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
