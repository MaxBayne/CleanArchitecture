using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Membership.Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Membership.Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "Name", "Password", "Role", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 20, 10, 29, 19, 401, DateTimeKind.Local).AddTicks(346), "admin1@gmail.com", "admin1", "123", "admins", 0, new DateTime(2023, 9, 20, 10, 29, 19, 401, DateTimeKind.Local).AddTicks(400) },
                    { 2, 1, new DateTime(2023, 9, 20, 10, 29, 19, 401, DateTimeKind.Local).AddTicks(408), "admin2@gmail.com", "admin2", "123", "admins", 0, new DateTime(2023, 9, 20, 10, 29, 19, 401, DateTimeKind.Local).AddTicks(411) },
                    { 3, 1, new DateTime(2023, 9, 20, 10, 29, 19, 401, DateTimeKind.Local).AddTicks(430), "user1@gmail.com", "user1", "456", "users", 0, new DateTime(2023, 9, 20, 10, 29, 19, 401, DateTimeKind.Local).AddTicks(433) },
                    { 4, 1, new DateTime(2023, 9, 20, 10, 29, 19, 401, DateTimeKind.Local).AddTicks(437), "user2@gmail.com", "user2", "456", "users", 0, new DateTime(2023, 9, 20, 10, 29, 19, 401, DateTimeKind.Local).AddTicks(440) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Membership.Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Membership.Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Membership.Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Membership.Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Membership.Users");
        }
    }
}
