using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addSectorPermissionToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectorsPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 1, 28, 16, 166, DateTimeKind.Local).AddTicks(2606), new DateTime(2022, 6, 30, 1, 28, 16, 167, DateTimeKind.Local).AddTicks(9098), new byte[] { 47, 65, 238, 80, 182, 233, 51, 68, 182, 177, 215, 103, 166, 137, 210, 99, 16, 91, 103, 177, 190, 15, 144, 125, 234, 88, 136, 252, 47, 96, 122, 51, 127, 183, 130, 86, 216, 34, 72, 105, 183, 162, 217, 227, 199, 79, 21, 226, 211, 218, 126, 232, 251, 24, 143, 188, 128, 114, 165, 100, 95, 145, 157, 191 }, new byte[] { 205, 97, 244, 42, 104, 54, 165, 23, 208, 167, 110, 79, 243, 31, 42, 219, 74, 82, 182, 1, 100, 76, 233, 165, 61, 155, 87, 85, 113, 107, 26, 50, 69, 122, 181, 106, 130, 110, 241, 106, 109, 167, 253, 203, 190, 168, 173, 231, 67, 82, 191, 191, 37, 251, 65, 104, 175, 21, 75, 48, 230, 197, 9, 32, 91, 250, 66, 105, 80, 177, 58, 149, 184, 12, 69, 173, 1, 143, 82, 83, 7, 190, 87, 235, 150, 250, 209, 111, 146, 79, 153, 135, 156, 7, 185, 123, 197, 229, 118, 252, 38, 139, 173, 172, 124, 90, 144, 58, 151, 218, 100, 211, 79, 201, 55, 150, 156, 138, 92, 236, 200, 105, 50, 144, 124, 246, 162, 219 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_SectorsPermissionsId",
                table: "Roles",
                column: "SectorsPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_SectorsPermissionsId",
                table: "Roles",
                column: "SectorsPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_SectorsPermissionsId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_SectorsPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SectorsPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 1, 18, 56, 190, DateTimeKind.Local).AddTicks(3672), new DateTime(2022, 6, 30, 1, 18, 56, 191, DateTimeKind.Local).AddTicks(5052), new byte[] { 48, 126, 64, 183, 200, 162, 117, 83, 175, 8, 244, 102, 176, 15, 138, 67, 81, 177, 212, 237, 249, 115, 108, 174, 185, 99, 115, 141, 15, 72, 11, 103, 43, 232, 219, 16, 113, 140, 84, 165, 76, 37, 45, 63, 241, 96, 212, 153, 147, 65, 218, 139, 39, 27, 51, 89, 44, 223, 155, 214, 206, 78, 26, 243 }, new byte[] { 182, 117, 53, 152, 175, 182, 196, 69, 197, 94, 34, 194, 222, 160, 177, 32, 179, 196, 108, 148, 167, 191, 124, 149, 137, 141, 53, 91, 145, 32, 236, 25, 141, 159, 182, 42, 8, 15, 57, 224, 229, 202, 32, 221, 160, 25, 99, 153, 61, 132, 59, 10, 250, 218, 252, 145, 129, 212, 252, 199, 83, 172, 53, 102, 227, 222, 95, 243, 238, 194, 16, 137, 234, 86, 182, 154, 189, 243, 224, 234, 81, 162, 136, 45, 194, 245, 230, 136, 238, 48, 255, 67, 131, 126, 131, 48, 182, 80, 206, 101, 158, 219, 240, 46, 160, 12, 132, 201, 108, 200, 187, 119, 124, 89, 255, 89, 158, 13, 51, 19, 48, 1, 91, 96, 187, 186, 28, 3 } });
        }
    }
}
