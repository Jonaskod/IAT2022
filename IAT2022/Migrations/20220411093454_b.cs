using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAT2022.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Customer = table.Column<int>(type: "INTEGER", nullable: true),
                    Product = table.Column<int>(type: "INTEGER", nullable: true),
                    IPR = table.Column<int>(type: "INTEGER", nullable: true),
                    Team = table.Column<int>(type: "INTEGER", nullable: true),
                    Buissness = table.Column<int>(type: "INTEGER", nullable: true),
                    Finance = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
