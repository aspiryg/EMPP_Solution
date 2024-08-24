using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMPP_Server.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InitialStageId",
                table: "MainInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InitialStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermsAndConditions = table.Column<bool>(type: "bit", nullable: false),
                    PrivacyPolicy = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmInformation = table.Column<bool>(type: "bit", nullable: false),
                    VolunteeringAvailability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolunteeringArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolunteeringSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeeklyVolunteeringHours = table.Column<int>(type: "int", nullable: false),
                    AgeConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    IsRefugee = table.Column<bool>(type: "bit", nullable: false),
                    IsLivingInCanada = table.Column<bool>(type: "bit", nullable: false),
                    WantToResideInQuebec = table.Column<bool>(type: "bit", nullable: false),
                    HasPreviousApplication = table.Column<bool>(type: "bit", nullable: false),
                    PreviousApplicationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialStages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainInfo_InitialStageId",
                table: "MainInfo",
                column: "InitialStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainInfo_InitialStages_InitialStageId",
                table: "MainInfo",
                column: "InitialStageId",
                principalTable: "InitialStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainInfo_InitialStages_InitialStageId",
                table: "MainInfo");

            migrationBuilder.DropTable(
                name: "InitialStages");

            migrationBuilder.DropIndex(
                name: "IX_MainInfo_InitialStageId",
                table: "MainInfo");

            migrationBuilder.DropColumn(
                name: "InitialStageId",
                table: "MainInfo");
        }
    }
}
