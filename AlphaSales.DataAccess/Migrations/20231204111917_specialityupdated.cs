using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSales.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class specialityupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_AspNetUsers_User_id",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Specialities_User_id",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "Specialities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_id",
                table: "Specialities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_User_id",
                table: "Specialities",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_AspNetUsers_User_id",
                table: "Specialities",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
