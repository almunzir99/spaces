using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addRestrictDeleteForTables : Migration
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
                values: new object[] { new DateTime(2022, 6, 30, 15, 55, 27, 188, DateTimeKind.Local).AddTicks(727), new DateTime(2022, 6, 30, 15, 55, 27, 189, DateTimeKind.Local).AddTicks(957), new byte[] { 22, 216, 86, 17, 93, 87, 221, 44, 249, 230, 173, 46, 207, 75, 103, 190, 230, 74, 36, 177, 112, 54, 83, 13, 200, 251, 140, 149, 97, 174, 98, 254, 134, 127, 98, 134, 156, 23, 54, 3, 198, 247, 139, 155, 76, 137, 148, 224, 40, 17, 148, 164, 239, 65, 91, 122, 0, 221, 52, 86, 1, 50, 139, 17 }, new byte[] { 159, 149, 224, 151, 92, 158, 49, 216, 94, 162, 66, 247, 64, 211, 103, 133, 40, 71, 88, 91, 181, 180, 66, 184, 63, 254, 99, 7, 236, 22, 58, 44, 147, 163, 232, 222, 211, 188, 27, 57, 222, 27, 227, 161, 148, 84, 76, 4, 240, 38, 55, 182, 151, 43, 249, 149, 125, 57, 227, 190, 149, 68, 155, 188, 181, 53, 224, 210, 138, 116, 203, 110, 177, 251, 88, 83, 204, 88, 162, 55, 9, 0, 138, 131, 187, 235, 109, 251, 100, 217, 107, 148, 65, 160, 176, 222, 173, 4, 96, 193, 113, 158, 219, 147, 141, 37, 26, 181, 75, 151, 212, 103, 0, 185, 238, 100, 226, 61, 137, 8, 163, 127, 215, 230, 244, 11, 115, 88 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                values: new object[] { new DateTime(2022, 6, 30, 15, 43, 52, 19, DateTimeKind.Local).AddTicks(181), new DateTime(2022, 6, 30, 15, 43, 52, 21, DateTimeKind.Local).AddTicks(1516), new byte[] { 77, 37, 72, 78, 142, 35, 246, 118, 43, 110, 51, 250, 153, 176, 168, 130, 50, 246, 3, 30, 151, 173, 211, 81, 8, 169, 178, 88, 254, 245, 89, 121, 109, 159, 132, 110, 211, 41, 174, 182, 242, 231, 61, 113, 252, 102, 206, 18, 184, 168, 121, 211, 235, 250, 188, 63, 165, 20, 105, 236, 9, 33, 146, 141 }, new byte[] { 68, 246, 59, 235, 239, 141, 249, 73, 243, 248, 158, 8, 114, 161, 205, 172, 203, 130, 55, 253, 193, 92, 13, 192, 211, 247, 221, 175, 17, 153, 46, 54, 115, 127, 158, 198, 76, 65, 132, 7, 42, 108, 57, 4, 159, 216, 111, 249, 109, 40, 7, 79, 90, 173, 246, 117, 39, 201, 109, 78, 121, 196, 203, 75, 210, 239, 123, 47, 36, 149, 78, 122, 212, 2, 224, 245, 218, 39, 243, 211, 1, 164, 223, 221, 247, 99, 240, 164, 145, 57, 224, 83, 144, 4, 208, 72, 210, 40, 101, 76, 75, 159, 95, 239, 233, 93, 218, 105, 160, 177, 12, 201, 180, 26, 136, 207, 64, 152, 235, 12, 46, 242, 60, 240, 50, 118, 231, 126 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
