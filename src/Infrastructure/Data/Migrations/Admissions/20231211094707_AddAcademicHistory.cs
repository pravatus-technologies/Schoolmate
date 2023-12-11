using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schoolmate.Infrastructure.Data.Migrations.Admissions
{
    /// <inheritdoc />
    public partial class AddAcademicHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    TelephoneNum = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    LastAcademicYearAttended = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicHistory_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicHistory_ApplicantId",
                table: "AcademicHistory",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicHistory");
        }
    }
}
