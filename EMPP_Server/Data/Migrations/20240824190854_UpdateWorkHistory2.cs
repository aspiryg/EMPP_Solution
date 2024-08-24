using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMPP_Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkHistory2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistory_InitialStages_ApplicationId",
                table: "WorkHistory");

            migrationBuilder.DropIndex(
                name: "IX_WorkHistory_ApplicationId",
                table: "WorkHistory");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "WorkHistory");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_AppId",
                table: "WorkHistory",
                column: "AppId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistory_InitialStages_AppId",
                table: "WorkHistory",
                column: "AppId",
                principalTable: "InitialStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistory_InitialStages_AppId",
                table: "WorkHistory");

            migrationBuilder.DropIndex(
                name: "IX_WorkHistory_AppId",
                table: "WorkHistory");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "WorkHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_ApplicationId",
                table: "WorkHistory",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistory_InitialStages_ApplicationId",
                table: "WorkHistory",
                column: "ApplicationId",
                principalTable: "InitialStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
