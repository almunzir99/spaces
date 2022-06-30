using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addRegionPermissionToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionsPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 8, 58, 16, 740, DateTimeKind.Local).AddTicks(8977), new DateTime(2022, 6, 30, 8, 58, 16, 742, DateTimeKind.Local).AddTicks(8308), new byte[] { 117, 53, 82, 94, 89, 111, 66, 65, 86, 22, 253, 156, 216, 41, 46, 53, 40, 159, 148, 4, 166, 25, 5, 204, 213, 220, 216, 228, 1, 115, 55, 189, 1, 61, 12, 214, 28, 77, 231, 7, 8, 40, 70, 41, 29, 202, 122, 229, 115, 97, 22, 120, 187, 244, 76, 59, 130, 37, 200, 160, 138, 147, 110, 253 }, new byte[] { 110, 102, 175, 59, 14, 139, 196, 13, 82, 163, 162, 30, 113, 83, 76, 99, 49, 93, 59, 190, 80, 131, 51, 144, 213, 230, 247, 6, 37, 136, 106, 157, 12, 140, 85, 140, 63, 34, 19, 242, 92, 133, 190, 70, 71, 66, 116, 116, 78, 240, 172, 53, 71, 241, 72, 178, 64, 176, 158, 189, 69, 85, 58, 153, 124, 130, 139, 156, 179, 109, 65, 252, 146, 100, 130, 101, 84, 243, 140, 143, 216, 23, 10, 21, 61, 220, 244, 2, 33, 87, 127, 35, 149, 9, 21, 77, 44, 149, 69, 198, 206, 47, 209, 120, 207, 71, 93, 15, 178, 162, 47, 85, 134, 224, 55, 91, 82, 232, 17, 126, 93, 74, 242, 141, 197, 41, 238, 252 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RegionsPermissionsId",
                table: "Roles",
                column: "RegionsPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_RegionsPermissionsId",
                table: "Roles",
                column: "RegionsPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_RegionsPermissionsId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RegionsPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RegionsPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 8, 47, 36, 459, DateTimeKind.Local).AddTicks(4971), new DateTime(2022, 6, 30, 8, 47, 36, 460, DateTimeKind.Local).AddTicks(5159), new byte[] { 72, 39, 82, 36, 16, 174, 231, 151, 96, 253, 246, 165, 179, 172, 232, 220, 118, 1, 77, 102, 191, 239, 240, 168, 188, 37, 205, 198, 49, 13, 186, 170, 242, 122, 103, 132, 6, 184, 203, 40, 186, 57, 47, 239, 40, 155, 206, 80, 102, 254, 107, 127, 44, 110, 255, 170, 107, 109, 252, 16, 21, 104, 233, 97 }, new byte[] { 191, 199, 67, 157, 95, 197, 7, 106, 214, 141, 73, 125, 40, 185, 155, 136, 25, 54, 222, 225, 100, 77, 191, 151, 74, 224, 214, 38, 223, 123, 175, 175, 0, 107, 65, 174, 193, 5, 160, 179, 53, 187, 185, 113, 34, 217, 102, 76, 173, 174, 253, 149, 43, 170, 136, 108, 57, 158, 236, 114, 49, 31, 242, 34, 201, 231, 147, 80, 190, 17, 25, 250, 233, 12, 120, 221, 30, 30, 4, 134, 24, 116, 98, 101, 156, 208, 113, 71, 173, 176, 118, 34, 154, 121, 24, 175, 40, 163, 216, 230, 161, 160, 184, 70, 204, 45, 152, 45, 235, 254, 16, 141, 15, 206, 20, 129, 245, 167, 63, 132, 195, 254, 250, 178, 139, 240, 121, 10 } });
        }
    }
}
