using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedBI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnalystTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Analysts");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Analysts",
                newName: "Specialty");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Analysts",
                newName: "Department");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Analysts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Analysts_UserId",
                table: "Analysts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analysts_AspNetUsers_UserId",
                table: "Analysts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analysts_AspNetUsers_UserId",
                table: "Analysts");

            migrationBuilder.DropIndex(
                name: "IX_Analysts_UserId",
                table: "Analysts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Analysts");

            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "Analysts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Analysts",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Analysts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
