using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class configure_game_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OnlineStore");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Library",
                table: "Books",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "OnlineStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "OnlineStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "OnlineStore",
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4524), new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4588) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4605), new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4607) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4614), new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4616) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4623), new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4625) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4631), new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4633) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4641), new DateTime(2024, 5, 11, 23, 37, 5, 986, DateTimeKind.Local).AddTicks(4643) });

            migrationBuilder.InsertData(
                schema: "OnlineStore",
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(5109), "Action", 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(5133) },
                    { 2, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(5144), "War", 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(5146) },
                    { 3, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(5152), "Family", 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(5154) },
                    { 4, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(5161), "Tricks", 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(5163) }
                });

            migrationBuilder.InsertData(
                schema: "OnlineStore",
                table: "Games",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "GenreId", "Name", "Price", "UpdatedBy", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1182), 1, "Street Fighter", 150m, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1209), 2010 },
                    { 2, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1223), 2, "Call of Duty", 98m, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1225), 2019 },
                    { 3, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1232), 2, "Medal Of Honor", 55m, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1234), 2018 },
                    { 4, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1240), 3, "Need For Speed", 870m, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1242), 2018 },
                    { 5, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1249), 1, "Freedom Fighter", 450m, 0, new DateTime(2024, 5, 11, 23, 37, 5, 987, DateTimeKind.Local).AddTicks(1251), 2017 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                schema: "OnlineStore",
                table: "Games",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games",
                schema: "OnlineStore");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "OnlineStore");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Library",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(1891), new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2112) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2142), new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2145) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2153), new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2156) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2164), new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2166) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2174), new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2176) });

            migrationBuilder.UpdateData(
                schema: "Library",
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2188), new DateTime(2024, 4, 26, 7, 24, 43, 654, DateTimeKind.Local).AddTicks(2190) });
        }
    }
}
