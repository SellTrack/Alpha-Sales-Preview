using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSales.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class userexerciseadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePlans_AspNetUsers_Client_id",
                table: "ExercisePlans");

            migrationBuilder.CreateTable(
                name: "UserExercisePlans",
                columns: table => new
                {
                    UserExercisePlan_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exercise_id = table.Column<int>(type: "int", nullable: false),
                    Client_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercisePlans", x => x.UserExercisePlan_id);
                    table.ForeignKey(
                        name: "FK_UserExercisePlans_AspNetUsers_Client_id",
                        column: x => x.Client_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserExercisePlans_ExercisePlans_Exercise_id",
                        column: x => x.Exercise_id,
                        principalTable: "ExercisePlans",
                        principalColumn: "ExercisePlan_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExercisePlans_Client_id",
                table: "UserExercisePlans",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercisePlans_Exercise_id",
                table: "UserExercisePlans",
                column: "Exercise_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePlans_AspNetUsers_Client_id",
                table: "ExercisePlans",
                column: "Client_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePlans_AspNetUsers_Client_id",
                table: "ExercisePlans");

            migrationBuilder.DropTable(
                name: "UserExercisePlans");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePlans_AspNetUsers_Client_id",
                table: "ExercisePlans",
                column: "Client_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
