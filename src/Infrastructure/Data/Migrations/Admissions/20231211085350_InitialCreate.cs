using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schoolmate.Infrastructure.Data.Migrations.Admissions
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LearnerRefNum = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    GivenNames = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    Birthplace = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    CivilStatus = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Baranggay = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Municipality = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    GivenNames = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    ParentType = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    HomeTelephone = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    MobileTelephone = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(75)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HighestEducationAttainment = table.Column<string>(type: "nvarchar(75)", nullable: true),
                    SchoolAttended = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IsDeceased = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentInformation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ApplicantId",
                table: "Address",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformation_ApplicantId",
                table: "ParentInformation",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ParentInformation");

            migrationBuilder.DropTable(
                name: "Applicant");
        }
    }
}
