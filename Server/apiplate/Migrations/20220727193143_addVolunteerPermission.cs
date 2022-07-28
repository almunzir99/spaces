using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addVolunteerPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VolunteersPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 27, 21, 31, 42, 389, DateTimeKind.Local).AddTicks(7173), new DateTime(2022, 7, 27, 21, 31, 42, 391, DateTimeKind.Local).AddTicks(2382), new byte[] { 199, 61, 97, 149, 173, 229, 203, 220, 191, 128, 249, 127, 166, 203, 132, 191, 82, 17, 177, 110, 28, 110, 80, 163, 174, 156, 208, 154, 71, 137, 185, 222, 253, 129, 191, 205, 43, 78, 15, 183, 26, 21, 10, 139, 143, 184, 147, 215, 159, 118, 176, 149, 237, 130, 80, 226, 17, 41, 6, 200, 10, 62, 226, 235 }, new byte[] { 25, 11, 51, 92, 240, 134, 31, 6, 33, 179, 91, 212, 72, 138, 153, 239, 149, 150, 134, 207, 112, 152, 42, 157, 36, 217, 18, 188, 233, 129, 66, 244, 254, 87, 32, 128, 205, 48, 78, 163, 107, 181, 145, 14, 130, 49, 134, 7, 215, 7, 220, 98, 211, 109, 10, 50, 97, 91, 146, 192, 215, 135, 182, 37, 6, 80, 208, 82, 242, 57, 251, 225, 90, 33, 222, 163, 133, 54, 128, 198, 60, 66, 119, 190, 196, 22, 48, 210, 234, 136, 136, 30, 134, 93, 168, 192, 250, 249, 15, 25, 133, 227, 201, 23, 207, 45, 87, 146, 237, 180, 108, 250, 163, 196, 162, 139, 210, 218, 65, 39, 202, 169, 203, 121, 233, 74, 90, 91 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_VolunteersPermissionsId",
                table: "Roles",
                column: "VolunteersPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_VolunteersPermissionsId",
                table: "Roles",
                column: "VolunteersPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_VolunteersPermissionsId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_VolunteersPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "VolunteersPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 27, 21, 25, 36, 14, DateTimeKind.Local).AddTicks(8159), new DateTime(2022, 7, 27, 21, 25, 36, 15, DateTimeKind.Local).AddTicks(7890), new byte[] { 49, 80, 80, 206, 252, 34, 97, 122, 117, 90, 51, 80, 180, 52, 138, 143, 219, 39, 215, 140, 211, 131, 252, 212, 42, 96, 176, 90, 135, 157, 31, 155, 0, 172, 251, 139, 158, 169, 221, 52, 249, 221, 120, 230, 97, 219, 192, 37, 98, 177, 147, 102, 242, 74, 101, 33, 205, 133, 169, 144, 127, 80, 0, 211 }, new byte[] { 29, 47, 11, 18, 110, 55, 81, 74, 192, 99, 233, 245, 100, 231, 47, 15, 14, 101, 73, 236, 187, 161, 95, 35, 151, 159, 158, 22, 96, 171, 108, 5, 157, 159, 113, 194, 8, 197, 75, 224, 189, 119, 28, 29, 118, 178, 95, 82, 116, 132, 252, 106, 114, 171, 6, 171, 247, 241, 249, 140, 215, 9, 92, 177, 47, 210, 121, 102, 60, 19, 60, 161, 160, 40, 119, 163, 107, 97, 184, 171, 75, 2, 255, 162, 76, 41, 142, 79, 201, 170, 233, 91, 94, 171, 223, 101, 24, 163, 237, 39, 192, 147, 252, 205, 82, 114, 194, 38, 184, 121, 55, 17, 129, 126, 91, 25, 177, 254, 145, 40, 190, 36, 99, 95, 190, 52, 172, 201 } });
        }
    }
}
