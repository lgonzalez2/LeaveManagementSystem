using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01aa158a-e53b-4a63-9806-afc30195c312", null, "Supervisor", "SUPERVISOR" },
                    { "e2a5c57d-8a1d-49e0-9b49-796c633fb5d5", null, "Employee", "EMPLOYEE" },
                    { "ec8f368a-c265-4d7a-bc8b-3f1acb27b77f", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e6db69f3-7231-4770-9927-c61b6c28801a", 0, "7084fab2-8b77-4b0f-86ff-347483ae1abe", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEImmVv1E2ES7Fbab8TalDgcmg30kYkEBgncATvaRAyub2ZVNtCzY7rKqAAFCi65Zgw==", null, false, "da7ac2c3-2c1e-4416-ade9-b0738f7630cb", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ec8f368a-c265-4d7a-bc8b-3f1acb27b77f", "e6db69f3-7231-4770-9927-c61b6c28801a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01aa158a-e53b-4a63-9806-afc30195c312");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2a5c57d-8a1d-49e0-9b49-796c633fb5d5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ec8f368a-c265-4d7a-bc8b-3f1acb27b77f", "e6db69f3-7231-4770-9927-c61b6c28801a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec8f368a-c265-4d7a-bc8b-3f1acb27b77f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a");
        }
    }
}
