using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecreioBarcode.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ChargerFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zona = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Rua = table.Column<int>(type: "int", nullable: false),
                    Estante = table.Column<int>(type: "int", nullable: false),
                    Prateleira = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemsOut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemsOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItemsOut_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItemsOut_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItemsOut_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsInventoried = table.Column<bool>(type: "bit", nullable: false),
                    InventoriedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryLocations_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLocations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    InventoryLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryLines_InventoryLocations_InventoryLocationId",
                        column: x => x.InventoryLocationId,
                        principalTable: "InventoryLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "ChargerFilePath", "CreatedAt", "FinishedAt", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "\\TesteFilePath", new DateTime(2026, 1, 6, 14, 59, 25, 0, DateTimeKind.Utc), null, true, "Inventário Teste" },
                    { 2, "\\\\TesteFilePath2", new DateTime(2026, 1, 6, 14, 59, 25, 0, DateTimeKind.Utc), new DateTime(2026, 1, 6, 14, 59, 25, 0, DateTimeKind.Utc), false, "Inventário Teste 2" }
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
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Thiago" },
                    { 2, "Pedro" },
                    { 3, "Franklin" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItemsOut",
                columns: new[] { "Id", "ItemCode", "Count", "InventoryId", "LocationId", "UserId" },
                values: new object[,]
                {
                    { 1, "jzz501211a", 2, 1, 5, 3},
                    { 2, "5q0201511b", 5, 2, 5, 1}

                });
            migrationBuilder.InsertData(
                table: "InventoryLocations",
                columns: new[] { "Id", "IsInventoried", "InventoriedAt", "InventoryId", "LocationId", "UserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 1, 6, 14, 59, 25, 590, DateTimeKind.Utc).AddTicks(3392), 1, 1, 1 },
                    { 2, false, null, 1, 2, null},
                    { 3, true, new DateTime(2026, 1, 6, 14, 59, 25, 590, DateTimeKind.Utc).AddTicks(3392), 2, 1, 2 },
                    { 4, false, null, 2, 2, null}

                });
            migrationBuilder.InsertData(
                table: "InventoryLines",
                columns: new[] { "Id", "ItemCode", "Count", "InventoryLocationId" },
                values: new object[,]
                {
                    { 1, "5u0998005b",0,1 },
                    { 2, "7l0005354c",1,2 },
                    { 3, "5u0998005b",3,3 },
                    { 4, "7l0005354c",5,4 },

                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemsOut_InventoryId",
                table: "InventoryItemsOut",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemsOut_LocationId",
                table: "InventoryItemsOut",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemsOut_UserId",
                table: "InventoryItemsOut",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLines_InventoryLocationId",
                table: "InventoryLines",
                column: "InventoryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_InventoryId",
                table: "InventoryLocations",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_LocationId",
                table: "InventoryLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_UserId",
                table: "InventoryLocations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItemsOut");

            migrationBuilder.DropTable(
                name: "InventoryLines");

            migrationBuilder.DropTable(
                name: "InventoryLocations");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
