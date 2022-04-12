using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAT2022.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "K8",
                table: "CustomerQuestions",
                newName: "K8b");

            migrationBuilder.RenameColumn(
                name: "K7",
                table: "CustomerQuestions",
                newName: "K8a");

            migrationBuilder.RenameColumn(
                name: "K6",
                table: "CustomerQuestions",
                newName: "K7b");

            migrationBuilder.RenameColumn(
                name: "K5",
                table: "CustomerQuestions",
                newName: "K7a");

            migrationBuilder.AddColumn<string>(
                name: "K5a",
                table: "CustomerQuestions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "K5b",
                table: "CustomerQuestions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "K6a",
                table: "CustomerQuestions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "K6b",
                table: "CustomerQuestions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "K5a",
                table: "CustomerQuestions");

            migrationBuilder.DropColumn(
                name: "K5b",
                table: "CustomerQuestions");

            migrationBuilder.DropColumn(
                name: "K6a",
                table: "CustomerQuestions");

            migrationBuilder.DropColumn(
                name: "K6b",
                table: "CustomerQuestions");

            migrationBuilder.RenameColumn(
                name: "K8b",
                table: "CustomerQuestions",
                newName: "K8");

            migrationBuilder.RenameColumn(
                name: "K8a",
                table: "CustomerQuestions",
                newName: "K7");

            migrationBuilder.RenameColumn(
                name: "K7b",
                table: "CustomerQuestions",
                newName: "K6");

            migrationBuilder.RenameColumn(
                name: "K7a",
                table: "CustomerQuestions",
                newName: "K5");
        }
    }
}
