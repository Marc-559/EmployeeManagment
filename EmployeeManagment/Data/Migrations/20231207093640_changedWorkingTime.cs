using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagment.Migrations
{
    /// <inheritdoc />
    public partial class changedWorkingTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_AspNetUsers_ApplicationUserId1",
                table: "WorkingTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkingTimes_ApplicationUserId1",
                table: "WorkingTimes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "WorkingTimes");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "WorkingTimes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_ApplicationUserId",
                table: "WorkingTimes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_AspNetUsers_ApplicationUserId",
                table: "WorkingTimes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_AspNetUsers_ApplicationUserId",
                table: "WorkingTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkingTimes_ApplicationUserId",
                table: "WorkingTimes");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "WorkingTimes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "WorkingTimes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_ApplicationUserId1",
                table: "WorkingTimes",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_AspNetUsers_ApplicationUserId1",
                table: "WorkingTimes",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
