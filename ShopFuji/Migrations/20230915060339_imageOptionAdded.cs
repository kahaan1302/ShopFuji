using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFuji.Migrations
{
    /// <inheritdoc />
    public partial class imageOptionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BinaryData",
                table: "Products",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "BinaryData");
        }
    }
}
