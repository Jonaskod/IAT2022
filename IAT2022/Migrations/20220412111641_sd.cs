using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAT2022.Migrations
{
    public partial class sd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CustomerPoco_CustomerId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPoco",
                table: "CustomerPoco");

            migrationBuilder.RenameTable(
                name: "CustomerPoco",
                newName: "CustomerValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerValue",
                table: "CustomerValue",
                column: "Id");

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
                    K5 = table.Column<string>(type: "TEXT", nullable: true),
                    K6 = table.Column<string>(type: "TEXT", nullable: true),
                    K7 = table.Column<string>(type: "TEXT", nullable: true),
                    K8 = table.Column<string>(type: "TEXT", nullable: true),
                    K9 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerQuestions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_CustomerValue_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "CustomerValue",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CustomerValue_CustomerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "CustomerQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerValue",
                table: "CustomerValue");

            migrationBuilder.RenameTable(
                name: "CustomerValue",
                newName: "CustomerPoco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPoco",
                table: "CustomerPoco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_CustomerPoco_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "CustomerPoco",
                principalColumn: "Id");
        }
    }
}
