using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedBI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNurseFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Patients_PatientId",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Patients_PatientId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Patients_PatientId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorLogs_AspNetUsers_UserId",
                table: "ErrorLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                table: "PatientAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientChronicConditions_Patients_PatientId",
                table: "PatientChronicConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientLabResults_Patients_PatientId",
                table: "PatientLabResults");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientLifestyles_Patients_PatientId",
                table: "PatientLifestyles");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientVitals_Patients_PatientId",
                table: "PatientVitals");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemLogs_AspNetUsers_UserId",
                table: "SystemLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "NavigationItemRoles");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "Messages",
                newName: "SentDate");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "NavigationItemRoles",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadDate",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Billings",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "Doctor");

            migrationBuilder.InsertData(
                table: "NavigationItemRoles",
                columns: new[] { "Id", "NavigationItemId", "RoleId" },
                values: new object[,]
                {
                    { 4, 2, "Doctor" },
                    { 5, 1, "Nurse" },
                    { 6, 2, "Nurse" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Patients_PatientId",
                table: "Billings",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Patients_PatientId",
                table: "Claims",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Patients_PatientId",
                table: "Documents",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorLogs_AspNetUsers_UserId",
                table: "ErrorLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                table: "PatientAllergies",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientChronicConditions_Patients_PatientId",
                table: "PatientChronicConditions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLabResults_Patients_PatientId",
                table: "PatientLabResults",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLifestyles_Patients_PatientId",
                table: "PatientLifestyles",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientVitals_Patients_PatientId",
                table: "PatientVitals",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemLogs_AspNetUsers_UserId",
                table: "SystemLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Patients_PatientId",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Patients_PatientId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Patients_PatientId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorLogs_AspNetUsers_UserId",
                table: "ErrorLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                table: "PatientAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientChronicConditions_Patients_PatientId",
                table: "PatientChronicConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientLabResults_Patients_PatientId",
                table: "PatientLabResults");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientLifestyles_Patients_PatientId",
                table: "PatientLifestyles");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientVitals_Patients_PatientId",
                table: "PatientVitals");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemLogs_AspNetUsers_UserId",
                table: "SystemLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "NavigationItemRoles");

            migrationBuilder.DropColumn(
                name: "ReadDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SentDate",
                table: "Messages",
                newName: "SentAt");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "NavigationItemRoles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Billings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.UpdateData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleName",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleName",
                value: "Customer");

            migrationBuilder.UpdateData(
                table: "NavigationItemRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleName",
                value: "Analyst");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Patients_PatientId",
                table: "Billings",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Patients_PatientId",
                table: "Claims",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Patients_PatientId",
                table: "Documents",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorLogs_AspNetUsers_UserId",
                table: "ErrorLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                table: "PatientAllergies",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientChronicConditions_Patients_PatientId",
                table: "PatientChronicConditions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLabResults_Patients_PatientId",
                table: "PatientLabResults",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLifestyles_Patients_PatientId",
                table: "PatientLifestyles",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientVitals_Patients_PatientId",
                table: "PatientVitals",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemLogs_AspNetUsers_UserId",
                table: "SystemLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
