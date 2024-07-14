using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[] { 2, "staff", "Staff", "staff" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[] { 3, "user", "User", "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "password", "user" });
        }
    }
}
