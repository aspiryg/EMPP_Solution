using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMPP_Server.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngApprovedTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CELPIPReading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CELPIPWriting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CELPIPSpeaking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CELPIPListening = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IELTSReading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IELTSWriting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IELTSSpeaking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IELTSListening = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PTEReading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PTEWriting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PTESpeaking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PTEListening = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoneDueLingo = table.Column<bool>(type: "bit", nullable: false),
                    DueLingoReading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueLingoWriting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueLingoSpeaking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueLingoListening = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrenchApprovedTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialStageId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageData_InitialStages_InitialStageId",
                        column: x => x.InitialStageId,
                        principalTable: "InitialStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Writing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speaking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Listening = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestLessThanTwoYears = table.Column<bool>(type: "bit", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageDataId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTests_LanguageData_LanguageDataId",
                        column: x => x.LanguageDataId,
                        principalTable: "LanguageData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageData_InitialStageId",
                table: "LanguageData",
                column: "InitialStageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTests_LanguageDataId",
                table: "LanguageTests",
                column: "LanguageDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageTests");

            migrationBuilder.DropTable(
                name: "LanguageData");
        }
    }
}
