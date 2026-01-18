using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecreioBarcode.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItemsOut_Locations_LocationId",
                table: "InventoryItemsOut");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItemsOut_Users_UserId",
                table: "InventoryItemsOut");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_Locations_LocationId",
                table: "InventoryLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_Users_UserId",
                table: "InventoryLocations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLocations_InventoryId",
                table: "InventoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLocations_UserId",
                table: "InventoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLines_InventoryLocationId",
                table: "InventoryLines");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItemsOut_LocationId",
                table: "InventoryItemsOut");

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InventoryLocations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "InventoryItemsOut");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "InventoryItemsOut",
                newName: "FoundLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItemsOut_UserId",
                table: "InventoryItemsOut",
                newName: "IX_InventoryItemsOut_FoundLocationId");

            migrationBuilder.RenameColumn(
                name: "ItStarted",
                table: "Inventories",
                newName: "IsOpen");

            migrationBuilder.AlterColumn<string>(
                name: "Zona",
                table: "Locations",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Prateleira",
                table: "Locations",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemCode",
                table: "InventoryLines",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "InventoryLines",
                type: "int",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ItemCode",
                table: "InventoryItemsOut",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Count",
                table: "InventoryItemsOut",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UX_Location_Zona_Rua_Estante_Prateleira_numero",
                table: "Locations",
                columns: new[] { "Zona", "Rua", "Estante", "Prateleira", "Numero" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Locations_Estante",
                table: "Locations",
                sql: "Estante BETWEEN 1 AND 999");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Locations_Numero",
                table: "Locations",
                sql: "Numero BETWEEN 1 AND 999");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Locations_Rua",
                table: "Locations",
                sql: "Rua BETWEEN 1 AND 99");

            migrationBuilder.CreateIndex(
                name: "UX_InventoryLocation_Inventory_Location",
                table: "InventoryLocations",
                columns: new[] { "InventoryId", "LocationId" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_InventoryLocations_InventoriedAt",
                table: "InventoryLocations",
                sql: "(IsInventoried = 0 AND InventoriedAt IS NULL) OR (IsInventoried = 1 AND InventoriedAt IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UX_InventoryLines_InventoryLocation_ItemCode",
                table: "InventoryLines",
                columns: new[] { "InventoryLocationId", "ItemCode" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Inventories_ActiveOpen",
                table: "Inventories",
                sql: "(IsActive = 1) OR (IsActive = 0 AND IsOpen = 0)");

            migrationBuilder.AddCheckConstraint(
                name: "Ck_Inventory_FinishedAt",
                table: "Inventories",
                sql: "(IsActive = 1 AND FinishedAt IS NULL) OR (IsActive = 0 AND FinishedAt IS NOT NULL)");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItemsOut_InventoryLocations_FoundLocationId",
                table: "InventoryItemsOut",
                column: "FoundLocationId",
                principalTable: "InventoryLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_Locations_LocationId",
                table: "InventoryLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItemsOut_InventoryLocations_FoundLocationId",
                table: "InventoryItemsOut");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_Locations_LocationId",
                table: "InventoryLocations");

            migrationBuilder.DropIndex(
                name: "UX_Location_Zona_Rua_Estante_Prateleira_numero",
                table: "Locations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Locations_Estante",
                table: "Locations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Locations_Numero",
                table: "Locations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Locations_Rua",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "UX_InventoryLocation_Inventory_Location",
                table: "InventoryLocations");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InventoryLocations_InventoriedAt",
                table: "InventoryLocations");

            migrationBuilder.DropIndex(
                name: "UX_InventoryLines_InventoryLocation_ItemCode",
                table: "InventoryLines");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Inventories_ActiveOpen",
                table: "Inventories");

            migrationBuilder.DropCheckConstraint(
                name: "Ck_Inventory_FinishedAt",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "FoundLocationId",
                table: "InventoryItemsOut",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItemsOut_FoundLocationId",
                table: "InventoryItemsOut",
                newName: "IX_InventoryItemsOut_UserId");

            migrationBuilder.RenameColumn(
                name: "IsOpen",
                table: "Inventories",
                newName: "ItStarted");

            migrationBuilder.AlterColumn<string>(
                name: "Zona",
                table: "Locations",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Prateleira",
                table: "Locations",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "InventoryLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemCode",
                table: "InventoryLines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "InventoryLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldPrecision: 10,
                oldScale: 2,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ItemCode",
                table: "InventoryItemsOut",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "InventoryItemsOut",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldDefaultValue: 1m);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "InventoryItemsOut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Inventories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedAt", "FinishedAt", "IsActive", "ItStarted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 6, 14, 59, 25, 0, DateTimeKind.Utc), null, true, false, "Inventário Teste" },
                    { 2, new DateTime(2026, 1, 6, 14, 59, 25, 0, DateTimeKind.Utc), new DateTime(2026, 1, 6, 14, 59, 25, 0, DateTimeKind.Utc), false, false, "Inventário Teste 2" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Estante", "Numero", "Prateleira", "Rua", "Zona" },
                values: new object[,]
                {
                    { 1, 1, 1, "A", 1, "A" },
                    { 2, 99, 1, "B", 2, "A" },
                    { 3, 99, 1, "C", 1, "B" },
                    { 4, 99, 2, "D", 2, "B" },
                    { 5, 99, 99, "Z", 99, "Z" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IpAdress", "Name" },
                values: new object[,]
                {
                    { 1, "", "Thiago" },
                    { 2, "", "Pedro" },
                    { 3, "", "Franklin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_InventoryId",
                table: "InventoryLocations",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_UserId",
                table: "InventoryLocations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLines_InventoryLocationId",
                table: "InventoryLines",
                column: "InventoryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemsOut_LocationId",
                table: "InventoryItemsOut",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItemsOut_Locations_LocationId",
                table: "InventoryItemsOut",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItemsOut_Users_UserId",
                table: "InventoryItemsOut",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_Locations_LocationId",
                table: "InventoryLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_Users_UserId",
                table: "InventoryLocations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
