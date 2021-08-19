using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.DataAccess.Migrations
{
    public partial class InitialDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedUser", "Email", "FirstName", "GenderId", "Gsm", "IsSuperVisor", "LastName", "PasswordHash", "PasswordSalt", "UserGroupId" },
                values: new object[] { 1, "Migration", "abdikurt@gmail.com", "Abdi", 2, "5423269293", true, "KURT", new byte[] { 161, 251, 139, 166, 222, 145, 86, 156, 231, 214, 134, 163, 33, 79, 242, 47, 253, 174, 133, 120, 82, 78, 76, 67, 152, 2, 109, 114, 6, 52, 177, 3, 53, 8, 16, 196, 113, 8, 232, 234, 173, 141, 175, 74, 9, 17, 139, 198, 164, 26, 5, 95, 231, 207, 226, 157, 133, 30, 227, 29, 33, 56, 150, 207 }, new byte[] { 151, 31, 4, 57, 184, 84, 196, 109, 2, 76, 92, 47, 193, 141, 127, 35, 237, 21, 160, 70, 198, 250, 179, 29, 122, 118, 220, 90, 91, 31, 251, 177, 64, 83, 167, 219, 111, 130, 163, 11, 30, 235, 186, 98, 238, 114, 124, 18, 120, 190, 179, 212, 233, 45, 139, 151, 110, 102, 12, 137, 198, 6, 216, 110, 226, 65, 178, 31, 220, 136, 25, 204, 247, 240, 48, 199, 18, 250, 195, 90, 70, 251, 210, 7, 120, 50, 129, 114, 112, 145, 252, 204, 26, 219, 89, 68, 148, 166, 39, 157, 123, 99, 172, 51, 96, 175, 207, 224, 12, 133, 229, 114, 120, 72, 210, 73, 241, 121, 71, 207, 127, 93, 71, 246, 179, 20, 201, 148 }, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
