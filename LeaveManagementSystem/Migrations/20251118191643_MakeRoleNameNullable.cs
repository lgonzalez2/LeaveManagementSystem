using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class MakeRoleNameNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a08f07c-1a4d-4107-9f22-abd8ab9fc0d1", "AQAAAAIAAYagAAAAEALjBUp99MpucK7JlJ3ry3nKBxIjfHCfkocUO/QwEnlyFpQrcVJ4W4LESkPo71k+mw==", "c5924e66-afae-4935-8d11-587f4effe8e3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c01eaa1-4513-4356-900d-04dbe15fc5b5", "AQAAAAIAAYagAAAAEAyImEErURskUHcjHXImZl+PI2AmFzVnKOuOjvCty8TglmykBMTzjsHMOvtbI4EJHg==", "c1140499-355b-4d8c-85aa-3bdc4f3a5a18" });
        }
    }
}
