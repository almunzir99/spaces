using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addClientCascadeForAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 43, 52, 19, DateTimeKind.Local).AddTicks(181), new DateTime(2022, 6, 30, 15, 43, 52, 21, DateTimeKind.Local).AddTicks(1516), new byte[] { 77, 37, 72, 78, 142, 35, 246, 118, 43, 110, 51, 250, 153, 176, 168, 130, 50, 246, 3, 30, 151, 173, 211, 81, 8, 169, 178, 88, 254, 245, 89, 121, 109, 159, 132, 110, 211, 41, 174, 182, 242, 231, 61, 113, 252, 102, 206, 18, 184, 168, 121, 211, 235, 250, 188, 63, 165, 20, 105, 236, 9, 33, 146, 141 }, new byte[] { 68, 246, 59, 235, 239, 141, 249, 73, 243, 248, 158, 8, 114, 161, 205, 172, 203, 130, 55, 253, 193, 92, 13, 192, 211, 247, 221, 175, 17, 153, 46, 54, 115, 127, 158, 198, 76, 65, 132, 7, 42, 108, 57, 4, 159, 216, 111, 249, 109, 40, 7, 79, 90, 173, 246, 117, 39, 201, 109, 78, 121, 196, 203, 75, 210, 239, 123, 47, 36, 149, 78, 122, 212, 2, 224, 245, 218, 39, 243, 211, 1, 164, 223, 221, 247, 99, 240, 164, 145, 57, 224, 83, 144, 4, 208, 72, 210, 40, 101, 76, 75, 159, 95, 239, 233, 93, 218, 105, 160, 177, 12, 201, 180, 26, 136, 207, 64, 152, 235, 12, 46, 242, 60, 240, 50, 118, 231, 126 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 14, 14, 403, DateTimeKind.Local).AddTicks(8252), new DateTime(2022, 6, 30, 11, 14, 14, 405, DateTimeKind.Local).AddTicks(2613), new byte[] { 160, 162, 191, 138, 45, 194, 205, 68, 31, 186, 67, 250, 112, 15, 81, 255, 185, 63, 85, 193, 23, 156, 115, 114, 114, 15, 249, 159, 8, 115, 23, 86, 168, 241, 48, 38, 43, 72, 130, 221, 36, 193, 203, 44, 107, 130, 95, 158, 181, 253, 89, 73, 64, 132, 62, 105, 86, 203, 74, 20, 50, 92, 103, 246 }, new byte[] { 15, 215, 120, 207, 209, 57, 251, 174, 133, 45, 38, 95, 62, 79, 143, 215, 86, 89, 237, 97, 118, 178, 239, 9, 178, 232, 175, 14, 99, 233, 86, 142, 200, 201, 197, 156, 243, 217, 41, 166, 106, 69, 128, 78, 112, 142, 126, 131, 190, 177, 151, 153, 145, 51, 254, 132, 22, 89, 233, 150, 224, 218, 145, 245, 203, 180, 205, 219, 16, 60, 145, 227, 153, 210, 34, 215, 0, 218, 83, 10, 157, 191, 94, 218, 106, 221, 40, 62, 132, 236, 81, 253, 152, 168, 7, 89, 168, 76, 6, 19, 115, 49, 209, 97, 13, 92, 190, 216, 52, 158, 24, 24, 202, 230, 24, 142, 46, 116, 79, 230, 180, 65, 74, 103, 104, 245, 228, 84 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
