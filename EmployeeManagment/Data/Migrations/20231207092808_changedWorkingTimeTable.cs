using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagment.Migrations
{
    /// <inheritdoc />
    public partial class changedWorkingTimeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_AspNetUsers_UserId",
                table: "WorkingTimes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkingTimes",
                newName: "ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingTimes_UserId",
                table: "WorkingTimes",
                newName: "IX_WorkingTimes_ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_AspNetUsers_ApplicationUserId1",
                table: "WorkingTimes",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_AspNetUsers_ApplicationUserId1",
                table: "WorkingTimes");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId1",
                table: "WorkingTimes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingTimes_ApplicationUserId1",
                table: "WorkingTimes",
                newName: "IX_WorkingTimes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_AspNetUsers_UserId",
                table: "WorkingTimes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
