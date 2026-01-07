using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecreioBarcode.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChargerFilePath",
                value: "\\TesteFilePath2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChargerFilePath",
                value: "\\\\TesteFilePath2");
        }
    }
}
