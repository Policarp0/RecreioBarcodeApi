using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecreioBarcode.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AAAAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalInventoriedLines",
                table: "InventoryLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalLines",
                table: "InventoryLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "TotalInventoriedLines",
                table: "InventoryLocations");

            migrationBuilder.DropColumn(
                name: "TotalLines",
                table: "InventoryLocations");
        }
    }
}
