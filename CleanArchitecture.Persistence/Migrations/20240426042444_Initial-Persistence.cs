using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialPersistence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Sales",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrdersItems",
                schema: "Sales",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    AdditionsValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    AdditionsPercent = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxesValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxesPercent = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrdersItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Sales",
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersItemsTaxes",
                schema: "Sales",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersItemsTaxes", x => x.TaxId);
                    table.ForeignKey(
                        name: "FK_OrdersItemsTaxes_OrdersItems_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Sales",
                        principalTable: "OrdersItems",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "Id", "Category", "CreatedBy", "CreatedDate", "Description", "IsActive", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Programming", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(1891), "Lean OOP inside C#", true, "OOP C#", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2112) },
                    { 2, "Programming", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2142), "Lean Rust Programming", true, "Rust", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2145) },
                    { 3, "Mobile", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2153), "Lean Android Programming", true, "Android", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2156) },
                    { 4, "Mobile", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2164), "Lean Flutter Programming", true, "Flutter", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2166) },
                    { 5, "Desktop", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2174), "Lean DevExpress For Desktop Apps", false, "DevExpress", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2176) },
                    { 6, "DataAccess", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2188), "Lean EntityFrameworkCore", false, "EntityFrameworkCore", 0, new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2190) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersItems_OrderId",
                schema: "Sales",
                table: "OrdersItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersItemsTaxes_OrderId",
                schema: "Sales",
                table: "OrdersItemsTaxes",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "OrdersItemsTaxes",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "OrdersItems",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Sales");
        }
    }
}
