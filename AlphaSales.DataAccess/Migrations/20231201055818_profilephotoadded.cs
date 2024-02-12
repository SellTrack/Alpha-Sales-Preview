using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaSales.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class profilephotoadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profilephotopath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilephotopath",
                table: "AspNetUsers");
        }
    }
}
