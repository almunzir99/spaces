using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addProjectsPermissionsToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectsPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 17, 24, 8, 161, DateTimeKind.Local).AddTicks(6556), new DateTime(2022, 6, 30, 17, 24, 8, 162, DateTimeKind.Local).AddTicks(6879), new byte[] { 179, 118, 142, 175, 255, 17, 129, 83, 49, 101, 90, 20, 139, 144, 44, 20, 47, 54, 208, 73, 30, 75, 251, 208, 54, 39, 181, 76, 11, 160, 71, 224, 234, 77, 238, 171, 169, 126, 170, 144, 178, 37, 25, 38, 110, 145, 238, 125, 68, 186, 91, 161, 5, 237, 122, 97, 74, 138, 221, 5, 245, 156, 8, 81 }, new byte[] { 66, 89, 150, 138, 231, 143, 252, 104, 34, 180, 135, 0, 84, 210, 106, 108, 115, 122, 144, 131, 161, 9, 178, 219, 7, 13, 98, 62, 174, 40, 21, 126, 29, 250, 215, 133, 144, 163, 196, 111, 38, 209, 146, 170, 133, 41, 254, 3, 155, 234, 119, 14, 103, 180, 12, 145, 247, 48, 72, 210, 128, 128, 191, 129, 141, 144, 120, 156, 231, 101, 194, 161, 143, 148, 136, 168, 9, 255, 167, 170, 83, 123, 216, 155, 137, 116, 32, 220, 243, 39, 129, 71, 193, 15, 68, 55, 148, 226, 36, 198, 155, 120, 195, 161, 240, 45, 150, 5, 99, 237, 200, 158, 87, 178, 110, 94, 14, 28, 142, 208, 85, 190, 244, 136, 9, 185, 133, 62 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ProjectsPermissionsId",
                table: "Roles",
                column: "ProjectsPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_ProjectsPermissionsId",
                table: "Roles",
                column: "ProjectsPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_ProjectsPermissionsId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ProjectsPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ProjectsPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 17, 10, 31, 117, DateTimeKind.Local).AddTicks(6230), new DateTime(2022, 6, 30, 17, 10, 31, 118, DateTimeKind.Local).AddTicks(7721), new byte[] { 85, 140, 81, 147, 132, 118, 29, 64, 135, 187, 129, 196, 185, 29, 162, 199, 42, 213, 245, 87, 202, 108, 102, 82, 77, 127, 115, 10, 196, 17, 241, 168, 6, 220, 108, 26, 248, 221, 47, 127, 90, 239, 188, 251, 217, 120, 112, 149, 165, 120, 100, 185, 210, 65, 24, 238, 218, 123, 246, 64, 237, 48, 251, 84 }, new byte[] { 101, 23, 100, 197, 141, 233, 199, 24, 255, 178, 241, 190, 217, 48, 11, 173, 185, 208, 155, 140, 9, 76, 17, 0, 211, 127, 137, 239, 43, 7, 241, 172, 4, 139, 90, 146, 76, 3, 222, 85, 36, 39, 26, 178, 200, 177, 184, 149, 194, 183, 84, 18, 122, 172, 47, 210, 132, 87, 66, 42, 195, 105, 3, 236, 94, 119, 59, 174, 66, 145, 194, 30, 39, 93, 82, 134, 168, 55, 224, 91, 179, 209, 251, 178, 27, 111, 238, 148, 235, 232, 125, 198, 50, 55, 131, 122, 93, 3, 51, 208, 134, 111, 121, 220, 203, 167, 28, 97, 153, 155, 150, 219, 85, 10, 224, 167, 32, 28, 189, 13, 116, 174, 55, 201, 121, 120, 186, 103 } });
        }
    }
}
