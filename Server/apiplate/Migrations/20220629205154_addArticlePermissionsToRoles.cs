using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addArticlePermissionsToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticlesPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 22, 51, 53, 406, DateTimeKind.Local).AddTicks(8075), new DateTime(2022, 6, 29, 22, 51, 53, 407, DateTimeKind.Local).AddTicks(9190), new byte[] { 92, 118, 77, 35, 207, 60, 7, 150, 220, 231, 160, 212, 123, 243, 80, 60, 162, 118, 236, 189, 16, 7, 133, 46, 19, 39, 33, 75, 127, 35, 128, 154, 74, 161, 106, 24, 131, 179, 137, 240, 5, 62, 119, 84, 131, 143, 11, 102, 157, 214, 246, 13, 69, 174, 241, 29, 108, 17, 111, 90, 244, 141, 43, 245 }, new byte[] { 41, 43, 184, 165, 123, 242, 82, 133, 29, 229, 99, 139, 30, 184, 107, 95, 102, 36, 246, 147, 36, 149, 111, 23, 119, 61, 218, 130, 15, 251, 79, 151, 35, 95, 52, 123, 1, 133, 77, 54, 58, 228, 220, 178, 104, 59, 70, 248, 15, 74, 20, 209, 34, 211, 223, 14, 94, 72, 82, 113, 1, 197, 96, 145, 199, 163, 56, 141, 78, 122, 26, 21, 151, 53, 145, 67, 75, 80, 76, 29, 83, 234, 210, 48, 244, 104, 199, 190, 189, 64, 104, 77, 55, 247, 176, 111, 154, 207, 151, 146, 115, 218, 27, 55, 162, 37, 108, 213, 47, 225, 89, 155, 208, 181, 91, 132, 189, 130, 17, 101, 167, 87, 150, 3, 10, 99, 5, 232 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ArticlesPermissionsId",
                table: "Roles",
                column: "ArticlesPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_ArticlesPermissionsId",
                table: "Roles",
                column: "ArticlesPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_ArticlesPermissionsId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ArticlesPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ArticlesPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 21, 41, 34, 60, DateTimeKind.Local).AddTicks(9002), new DateTime(2022, 6, 29, 21, 41, 34, 61, DateTimeKind.Local).AddTicks(9920), new byte[] { 41, 90, 30, 102, 183, 76, 249, 39, 171, 108, 222, 169, 70, 9, 30, 189, 226, 178, 145, 55, 5, 96, 185, 238, 23, 155, 225, 233, 228, 179, 206, 41, 164, 99, 125, 239, 112, 188, 64, 57, 96, 55, 220, 255, 98, 154, 119, 156, 15, 179, 212, 163, 106, 120, 21, 140, 32, 176, 39, 243, 18, 30, 62, 110 }, new byte[] { 152, 192, 114, 116, 72, 14, 211, 22, 75, 85, 199, 148, 194, 16, 112, 146, 241, 39, 93, 144, 90, 246, 252, 30, 163, 205, 117, 73, 119, 28, 194, 52, 66, 217, 113, 15, 160, 97, 60, 1, 177, 150, 39, 105, 65, 189, 167, 109, 62, 71, 158, 16, 146, 3, 72, 179, 211, 141, 239, 142, 195, 120, 174, 182, 174, 186, 85, 254, 255, 196, 213, 240, 60, 253, 117, 28, 73, 222, 138, 162, 173, 136, 21, 52, 102, 251, 145, 231, 40, 71, 132, 7, 198, 31, 7, 70, 63, 212, 40, 17, 97, 10, 202, 32, 153, 85, 78, 210, 140, 232, 252, 36, 24, 127, 86, 32, 31, 2, 150, 147, 175, 40, 240, 109, 218, 108, 155, 147 } });
        }
    }
}
