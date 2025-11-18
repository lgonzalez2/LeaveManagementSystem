using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleNameAndRolesToRegisterVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c01eaa1-4513-4356-900d-04dbe15fc5b5", "AQAAAAIAAYagAAAAEAyImEErURskUHcjHXImZl+PI2AmFzVnKOuOjvCty8TglmykBMTzjsHMOvtbI4EJHg==", "c1140499-355b-4d8c-85aa-3bdc4f3a5a18" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7084fab2-8b77-4b0f-86ff-347483ae1abe", "AQAAAAIAAYagAAAAEImmVv1E2ES7Fbab8TalDgcmg30kYkEBgncATvaRAyub2ZVNtCzY7rKqAAFCi65Zgw==", "da7ac2c3-2c1e-4416-ade9-b0738f7630cb" });
        }
    }
}
