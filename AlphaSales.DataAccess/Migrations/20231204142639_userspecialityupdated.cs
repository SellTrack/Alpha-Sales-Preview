using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSales.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class userspecialityupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserSpecialities_Speciality_id",
                table: "UserSpecialities",
                column: "Speciality_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSpecialities_Specialities_Speciality_id",
                table: "UserSpecialities",
                column: "Speciality_id",
                principalTable: "Specialities",
                principalColumn: "Speciality_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSpecialities_Specialities_Speciality_id",
                table: "UserSpecialities");

            migrationBuilder.DropIndex(
                name: "IX_UserSpecialities_Speciality_id",
                table: "UserSpecialities");
        }
    }
}
