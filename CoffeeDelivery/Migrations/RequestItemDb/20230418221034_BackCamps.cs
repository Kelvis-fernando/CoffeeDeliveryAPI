using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeDelivery.Migrations.RequestItemDb
{
    /// <inheritdoc />
    public partial class BackCamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prices",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Products",
                table: "RequestItems");

            migrationBuilder.RenameColumn(
                name: "QtdAddedToCart",
                table: "RequestItems",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Itensity",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "RequestItems",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TypeToast",
                table: "RequestItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Classification",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Itensity",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RequestItems");

            migrationBuilder.DropColumn(
                name: "TypeToast",
                table: "RequestItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "RequestItems",
                newName: "QtdAddedToCart");

            migrationBuilder.AddColumn<int>(
                name: "Prices",
                table: "RequestItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Products",
                table: "RequestItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
