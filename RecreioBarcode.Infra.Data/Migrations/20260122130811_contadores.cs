using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecreioBarcode.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class contadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalInventoriedLines",
                table: "InventoryLocations");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Inventories",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TotalInventoriedLocations",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalItemsOut",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalLines",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalLocations",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "TotalInventoriedLocations",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "TotalItemsOut",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "TotalLines",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "TotalLocations",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "TotalInventoriedLines",
                table: "InventoryLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
