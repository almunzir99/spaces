using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addTeamPermissionToRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 14, 14, 403, DateTimeKind.Local).AddTicks(8252), new DateTime(2022, 6, 30, 11, 14, 14, 405, DateTimeKind.Local).AddTicks(2613), new byte[] { 160, 162, 191, 138, 45, 194, 205, 68, 31, 186, 67, 250, 112, 15, 81, 255, 185, 63, 85, 193, 23, 156, 115, 114, 114, 15, 249, 159, 8, 115, 23, 86, 168, 241, 48, 38, 43, 72, 130, 221, 36, 193, 203, 44, 107, 130, 95, 158, 181, 253, 89, 73, 64, 132, 62, 105, 86, 203, 74, 20, 50, 92, 103, 246 }, new byte[] { 15, 215, 120, 207, 209, 57, 251, 174, 133, 45, 38, 95, 62, 79, 143, 215, 86, 89, 237, 97, 118, 178, 239, 9, 178, 232, 175, 14, 99, 233, 86, 142, 200, 201, 197, 156, 243, 217, 41, 166, 106, 69, 128, 78, 112, 142, 126, 131, 190, 177, 151, 153, 145, 51, 254, 132, 22, 89, 233, 150, 224, 218, 145, 245, 203, 180, 205, 219, 16, 60, 145, 227, 153, 210, 34, 215, 0, 218, 83, 10, 157, 191, 94, 218, 106, 221, 40, 62, 132, 236, 81, 253, 152, 168, 7, 89, 168, 76, 6, 19, 115, 49, 209, 97, 13, 92, 190, 216, 52, 158, 24, 24, 202, 230, 24, 142, 46, 116, 79, 230, 180, 65, 74, 103, 104, 245, 228, 84 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_TeamPermissionsId",
                table: "Roles",
                column: "TeamPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_TeamPermissionsId",
                table: "Roles",
                column: "TeamPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_TeamPermissionsId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_TeamPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TeamPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 12, 44, 646, DateTimeKind.Local).AddTicks(1659), new DateTime(2022, 6, 30, 11, 12, 44, 648, DateTimeKind.Local).AddTicks(25), new byte[] { 49, 141, 17, 220, 160, 10, 188, 254, 134, 65, 100, 199, 47, 1, 204, 91, 18, 243, 213, 172, 78, 28, 106, 238, 49, 96, 182, 253, 161, 149, 157, 97, 135, 96, 236, 28, 177, 150, 84, 10, 66, 21, 187, 200, 169, 184, 176, 237, 38, 14, 48, 27, 64, 251, 154, 229, 186, 101, 60, 93, 4, 66, 231, 226 }, new byte[] { 160, 138, 210, 75, 196, 143, 206, 178, 38, 147, 123, 47, 168, 148, 58, 210, 203, 41, 14, 234, 15, 88, 94, 247, 189, 85, 213, 29, 70, 99, 2, 218, 97, 193, 121, 18, 206, 46, 88, 240, 242, 56, 94, 110, 150, 68, 109, 29, 149, 232, 218, 249, 82, 87, 128, 106, 70, 71, 21, 254, 241, 193, 44, 187, 73, 111, 9, 121, 62, 53, 180, 168, 56, 9, 16, 48, 201, 65, 167, 98, 231, 46, 68, 173, 252, 171, 135, 252, 1, 8, 44, 110, 229, 150, 207, 43, 113, 40, 102, 121, 33, 7, 125, 199, 183, 145, 70, 189, 162, 224, 0, 244, 114, 154, 44, 225, 62, 213, 67, 154, 146, 240, 126, 143, 194, 148, 152, 165 } });
        }
    }
}
