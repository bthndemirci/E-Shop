using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.DataAccess.Migrations
{
    public partial class InitialDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Son Kullanıcı" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
