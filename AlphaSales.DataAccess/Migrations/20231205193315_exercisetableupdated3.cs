using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSales.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class exercisetableupdated3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client_id",
                table: "ExercisePlans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client_id",
                table: "ExercisePlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
