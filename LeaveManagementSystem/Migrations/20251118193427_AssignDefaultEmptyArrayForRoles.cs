using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AssignDefaultEmptyArrayForRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feaacf18-c1d2-4b4c-87ab-f35eadecddb0", "AQAAAAIAAYagAAAAENVqYiohIKAmZlus8uQohaVekJA2c2JdL4P0RpT3it1GOcqU7yOMptRJT9nyGHNJHQ==", "4a8c9342-b008-43b9-86a0-96c55e41f32c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b065218e-a3b9-499c-a8f6-6e7c5f2fb819", "AQAAAAIAAYagAAAAEA8eRZRlcUiNSFf9K4oe2ROnO5ti8PN1StaLbZmMzRCSvUVkRZ8O8kMjPUNqvoVmzw==", "53b478e9-5c7e-4a6e-ac55-e99da120d26d" });
        }
    }
}
