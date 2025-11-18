using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b065218e-a3b9-499c-a8f6-6e7c5f2fb819", "AQAAAAIAAYagAAAAEA8eRZRlcUiNSFf9K4oe2ROnO5ti8PN1StaLbZmMzRCSvUVkRZ8O8kMjPUNqvoVmzw==", "53b478e9-5c7e-4a6e-ac55-e99da120d26d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a08f07c-1a4d-4107-9f22-abd8ab9fc0d1", "AQAAAAIAAYagAAAAEALjBUp99MpucK7JlJ3ry3nKBxIjfHCfkocUO/QwEnlyFpQrcVJ4W4LESkPo71k+mw==", "c5924e66-afae-4935-8d11-587f4effe8e3" });
        }
    }
}
