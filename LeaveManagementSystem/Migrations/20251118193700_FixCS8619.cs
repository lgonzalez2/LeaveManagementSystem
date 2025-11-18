using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixCS8619 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59e1191f-3f7e-43b0-8971-ea66d7013224", "AQAAAAIAAYagAAAAEKDWmGniTirmKJBtDpXo6PipGlflV11tE7LfIduKaG/FbJqXWSzg9F+YgcR1dfIYzQ==", "37582766-333d-49c3-9063-ce7106685ca1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6db69f3-7231-4770-9927-c61b6c28801a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feaacf18-c1d2-4b4c-87ab-f35eadecddb0", "AQAAAAIAAYagAAAAENVqYiohIKAmZlus8uQohaVekJA2c2JdL4P0RpT3it1GOcqU7yOMptRJT9nyGHNJHQ==", "4a8c9342-b008-43b9-86a0-96c55e41f32c" });
        }
    }
}
