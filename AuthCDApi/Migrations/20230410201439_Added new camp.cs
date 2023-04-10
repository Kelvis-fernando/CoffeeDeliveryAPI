using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthCDApi.Migrations
{
    /// <inheritdoc />
    public partial class Addednewcamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOfUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfUser",
                table: "Users");
        }
    }
}
