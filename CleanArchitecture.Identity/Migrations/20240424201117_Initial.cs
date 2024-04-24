using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UsersLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPermissions",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn1 = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPermissions", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UsersPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Identity",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UsersTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => new { x.UserId, x.RoleId });
                    
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Can Insert Data", "CanInsert" },
                    { 2, "Can Update Data", "CanUpdate" },
                    { 3, "Can Delete Data", "CanDelete" },
                    { 4, "Can Print Data", "CanPrint" },
                    { 5, "Can Import Data", "CanImport" },
                    { 6, "Can Export Data", "CanExport" },
                    { 7, "Can View Data", "CanView" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("337d96c5-6ab6-40b9-b2a3-47166e861366"), null, "Users", "USERS" },
                    { new Guid("447d96c5-6ab6-40b9-b2a3-47166e861366"), null, "Supervisors", "SUPERVISORS" },
                    { new Guid("557d96c5-6ab6-40b9-b2a3-47166e861366"), null, "Administrators", "ADMINISTRATORS" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1b345d5d-4714-401f-b124-32836d210679"), 0, "63dee25c-171c-4cab-81c7-2b5f9ed02856", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAELgNG5/UuEYnCbkFWN+CKmm7nMkw4ws8mCKXwrd6ehYbzepJTj1TkmC52I7JGUX1uQ==", null, false, "123", false, "admin" },
                    { new Guid("2b345d5d-4714-401f-b124-32836d210679"), 0, "68898c89-1b09-46b9-8851-f8493ef10937", "supervisor@gmail.com", false, false, null, "SUPERVISOR@GMAIL.COM", "SUPERVISOR", "AQAAAAIAAYagAAAAED8d8VIlqpBtGv1LyYCsPEW7Lyn+BkhR2Rk+O0feNm04YRmc0xqDxiHVXLWqkKPHBw==", null, false, "123", false, "supervisor" },
                    { new Guid("3b345d5d-4714-401f-b124-32836d210679"), 0, "0121cf17-9ef6-4e14-9879-6d36cdfae834", "user@gmail.com", false, false, null, "USER@GMAIL.COM", "USER", "AQAAAAIAAYagAAAAECnk59tvsC6Yh/aRD8IscozMZnYLu73/1nRv1tf1xvkpj3wUUB2bv41LBXN+A1hGJw==", null, false, "123", false, "user" }
                });

            

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UsersPermissions",
                columns: new[] { "PermissionId", "UserId", "UpdatedOn", "UpdatedOn1" },
                values: new object[,]
                {
                    { 1, new Guid("1b345d5d-4714-401f-b124-32836d210679"), new DateTime(2024, 4, 24, 22, 11, 16, 873, DateTimeKind.Local).AddTicks(173), new DateTime(2024, 4, 24, 22, 11, 16, 873, DateTimeKind.Local).AddTicks(246) },
                    { 2, new Guid("1b345d5d-4714-401f-b124-32836d210679"), new DateTime(2024, 4, 24, 22, 11, 16, 873, DateTimeKind.Local).AddTicks(263), new DateTime(2024, 4, 24, 22, 11, 16, 873, DateTimeKind.Local).AddTicks(267) },
                    { 3, new Guid("1b345d5d-4714-401f-b124-32836d210679"), new DateTime(2024, 4, 24, 22, 11, 16, 873, DateTimeKind.Local).AddTicks(273), new DateTime(2024, 4, 24, 22, 11, 16, 873, DateTimeKind.Local).AddTicks(276) },
                    { 7, new Guid("1b345d5d-4714-401f-b124-32836d210679"), new DateTime(2024, 4, 24, 22, 11, 16, 873, DateTimeKind.Local).AddTicks(291), new DateTime(2024, 4, 24, 22, 11, 16, 873, DateTimeKind.Local).AddTicks(294) }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("337d96c5-6ab6-40b9-b2a3-47166e861366"), new Guid("1b345d5d-4714-401f-b124-32836d210679") },
                    { new Guid("447d96c5-6ab6-40b9-b2a3-47166e861366"), new Guid("1b345d5d-4714-401f-b124-32836d210679") },
                    { new Guid("557d96c5-6ab6-40b9-b2a3-47166e861366"), new Guid("1b345d5d-4714-401f-b124-32836d210679") },
                    { new Guid("337d96c5-6ab6-40b9-b2a3-47166e861366"), new Guid("2b345d5d-4714-401f-b124-32836d210679") },
                    { new Guid("447d96c5-6ab6-40b9-b2a3-47166e861366"), new Guid("2b345d5d-4714-401f-b124-32836d210679") },
                    { new Guid("337d96c5-6ab6-40b9-b2a3-47166e861366"), new Guid("3b345d5d-4714-401f-b124-32836d210679") }
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolesClaims_RoleId",
                schema: "Identity",
                table: "RolesClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersClaims_UserId",
                schema: "Identity",
                table: "UsersClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLogins_UserId",
                schema: "Identity",
                table: "UsersLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPermissions_PermissionId",
                schema: "Identity",
                table: "UsersPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                schema: "Identity",
                table: "UsersRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersPermissions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");
        }
    }
}
