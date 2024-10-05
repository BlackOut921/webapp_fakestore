using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_fakestore.Migrations
{
    /// <inheritdoc />
    public partial class _gendercat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductGenderTarget",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductGenderTarget",
                table: "Products");
        }
    }
}
