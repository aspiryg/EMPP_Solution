using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMPP_Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitialStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationMainCategory",
                table: "InitialStages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStage",
                table: "InitialStages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "InitialStages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationSubCategory",
                table: "InitialStages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationType",
                table: "InitialStages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationMainCategory",
                table: "InitialStages");

            migrationBuilder.DropColumn(
                name: "ApplicationStage",
                table: "InitialStages");

            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "InitialStages");

            migrationBuilder.DropColumn(
                name: "ApplicationSubCategory",
                table: "InitialStages");

            migrationBuilder.DropColumn(
                name: "ApplicationType",
                table: "InitialStages");
        }
    }
}
