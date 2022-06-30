using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addPartnersPermissionsToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartnersPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 16, 10, 38, 540, DateTimeKind.Local).AddTicks(6747), new DateTime(2022, 6, 30, 16, 10, 38, 541, DateTimeKind.Local).AddTicks(7210), new byte[] { 79, 57, 49, 217, 221, 35, 13, 31, 171, 208, 171, 157, 73, 35, 63, 229, 189, 149, 90, 52, 227, 223, 135, 58, 20, 144, 11, 89, 123, 173, 207, 113, 54, 107, 74, 12, 118, 112, 170, 255, 75, 234, 212, 216, 33, 97, 0, 211, 58, 14, 119, 118, 217, 128, 50, 37, 111, 201, 149, 110, 43, 168, 132, 208 }, new byte[] { 201, 48, 26, 209, 91, 95, 107, 137, 152, 198, 3, 114, 146, 230, 98, 45, 249, 87, 203, 250, 239, 141, 142, 122, 250, 248, 85, 202, 183, 170, 132, 234, 103, 106, 187, 8, 34, 176, 217, 40, 200, 212, 207, 10, 135, 61, 125, 116, 69, 147, 157, 138, 65, 226, 58, 20, 11, 164, 219, 140, 75, 43, 119, 30, 51, 211, 75, 75, 122, 46, 110, 203, 133, 77, 4, 18, 181, 112, 67, 79, 149, 130, 139, 72, 186, 45, 187, 252, 181, 244, 138, 244, 87, 163, 234, 116, 75, 254, 161, 118, 214, 193, 143, 165, 36, 179, 105, 66, 105, 224, 193, 58, 181, 251, 134, 241, 152, 36, 86, 105, 117, 220, 36, 124, 122, 19, 158, 141 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PartnersPermissionsId",
                table: "Roles",
                column: "PartnersPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_PartnersPermissionsId",
                table: "Roles",
                column: "PartnersPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_PartnersPermissionsId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PartnersPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PartnersPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 16, 3, 33, 660, DateTimeKind.Local).AddTicks(5548), new DateTime(2022, 6, 30, 16, 3, 33, 662, DateTimeKind.Local).AddTicks(1584), new byte[] { 88, 112, 211, 235, 203, 201, 192, 243, 179, 137, 144, 23, 91, 35, 234, 47, 233, 95, 171, 54, 246, 167, 3, 7, 251, 110, 244, 192, 177, 15, 228, 94, 6, 97, 17, 103, 104, 26, 44, 55, 212, 153, 241, 18, 127, 125, 200, 214, 152, 154, 201, 106, 246, 1, 239, 28, 122, 143, 106, 104, 154, 139, 194, 47 }, new byte[] { 197, 27, 172, 17, 20, 27, 4, 198, 2, 7, 41, 84, 137, 134, 73, 72, 59, 140, 172, 4, 174, 240, 113, 243, 189, 13, 118, 68, 21, 250, 217, 19, 186, 102, 113, 178, 151, 161, 40, 28, 230, 254, 242, 16, 246, 236, 253, 106, 51, 209, 60, 148, 218, 247, 253, 236, 162, 137, 245, 172, 245, 16, 30, 113, 211, 37, 87, 50, 8, 52, 52, 215, 252, 51, 42, 253, 187, 96, 12, 121, 10, 39, 177, 217, 158, 209, 109, 93, 99, 15, 26, 199, 162, 241, 133, 82, 175, 95, 193, 233, 206, 149, 237, 44, 233, 119, 24, 62, 220, 39, 71, 239, 10, 244, 231, 211, 169, 151, 247, 230, 98, 190, 134, 244, 120, 65, 54, 37 } });
        }
    }
}
