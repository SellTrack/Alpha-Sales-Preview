using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSales.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class exercisetableupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePlans_AspNetUsers_Client_id",
                table: "ExercisePlans");

            migrationBuilder.DropIndex(
                name: "IX_ExercisePlans_Client_id",
                table: "ExercisePlans");

            migrationBuilder.AlterColumn<string>(
                name: "Client_id",
                table: "ExercisePlans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Client_id",
                table: "ExercisePlans",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePlans_Client_id",
                table: "ExercisePlans",
                column: "Client_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePlans_AspNetUsers_Client_id",
                table: "ExercisePlans",
                column: "Client_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
