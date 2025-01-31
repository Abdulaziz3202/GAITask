using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GAITask.Migrations
{
    /// <inheritdoc />
    public partial class fixtasktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AbpUsers_AssignedToId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "Tasks");

            migrationBuilder.AlterColumn<long>(
                name: "AssignedToId",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AbpUsers_AssignedToId",
                table: "Tasks",
                column: "AssignedToId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AbpUsers_AssignedToId",
                table: "Tasks");

            migrationBuilder.AlterColumn<long>(
                name: "AssignedToId",
                table: "Tasks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AssignedToUserId",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AbpUsers_AssignedToId",
                table: "Tasks",
                column: "AssignedToId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}
