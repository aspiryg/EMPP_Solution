using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMPP_Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistory_MainInfo_MainInfoId",
                table: "WorkHistory");

            migrationBuilder.RenameColumn(
                name: "MainInfoId",
                table: "WorkHistory",
                newName: "ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkHistory_MainInfoId",
                table: "WorkHistory",
                newName: "IX_WorkHistory_ApplicationId");

            migrationBuilder.AddColumn<int>(
                name: "AppId",
                table: "WorkHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistory_InitialStages_ApplicationId",
                table: "WorkHistory",
                column: "ApplicationId",
                principalTable: "InitialStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistory_InitialStages_ApplicationId",
                table: "WorkHistory");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "WorkHistory");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "WorkHistory",
                newName: "MainInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkHistory_ApplicationId",
                table: "WorkHistory",
                newName: "IX_WorkHistory_MainInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistory_MainInfo_MainInfoId",
                table: "WorkHistory",
                column: "MainInfoId",
                principalTable: "MainInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
