using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addImageToRegionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 8, 47, 36, 459, DateTimeKind.Local).AddTicks(4971), new DateTime(2022, 6, 30, 8, 47, 36, 460, DateTimeKind.Local).AddTicks(5159), new byte[] { 72, 39, 82, 36, 16, 174, 231, 151, 96, 253, 246, 165, 179, 172, 232, 220, 118, 1, 77, 102, 191, 239, 240, 168, 188, 37, 205, 198, 49, 13, 186, 170, 242, 122, 103, 132, 6, 184, 203, 40, 186, 57, 47, 239, 40, 155, 206, 80, 102, 254, 107, 127, 44, 110, 255, 170, 107, 109, 252, 16, 21, 104, 233, 97 }, new byte[] { 191, 199, 67, 157, 95, 197, 7, 106, 214, 141, 73, 125, 40, 185, 155, 136, 25, 54, 222, 225, 100, 77, 191, 151, 74, 224, 214, 38, 223, 123, 175, 175, 0, 107, 65, 174, 193, 5, 160, 179, 53, 187, 185, 113, 34, 217, 102, 76, 173, 174, 253, 149, 43, 170, 136, 108, 57, 158, 236, 114, 49, 31, 242, 34, 201, 231, 147, 80, 190, 17, 25, 250, 233, 12, 120, 221, 30, 30, 4, 134, 24, 116, 98, 101, 156, 208, 113, 71, 173, 176, 118, 34, 154, 121, 24, 175, 40, 163, 216, 230, 161, 160, 184, 70, 204, 45, 152, 45, 235, 254, 16, 141, 15, 206, 20, 129, 245, 167, 63, 132, 195, 254, 250, 178, 139, 240, 121, 10 } });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ImageId",
                table: "Regions",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Images_ImageId",
                table: "Regions",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Images_ImageId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_ImageId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Regions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 8, 43, 23, 62, DateTimeKind.Local).AddTicks(692), new DateTime(2022, 6, 30, 8, 43, 23, 63, DateTimeKind.Local).AddTicks(2125), new byte[] { 35, 197, 150, 248, 156, 121, 162, 222, 164, 193, 179, 191, 43, 174, 187, 160, 243, 141, 19, 140, 203, 129, 101, 82, 51, 200, 61, 246, 57, 126, 126, 208, 59, 67, 11, 47, 191, 99, 149, 249, 9, 58, 233, 173, 181, 240, 53, 163, 86, 190, 60, 92, 142, 240, 119, 105, 169, 184, 120, 75, 120, 236, 238, 251 }, new byte[] { 50, 62, 82, 0, 213, 173, 16, 84, 181, 90, 219, 91, 181, 42, 172, 73, 98, 125, 81, 219, 176, 62, 84, 184, 105, 60, 157, 187, 120, 230, 112, 42, 4, 251, 150, 44, 124, 80, 136, 255, 57, 102, 94, 19, 41, 155, 107, 134, 159, 55, 132, 85, 140, 199, 163, 204, 97, 44, 82, 159, 97, 178, 26, 213, 94, 251, 1, 96, 181, 171, 218, 115, 159, 8, 83, 10, 119, 204, 51, 237, 144, 37, 136, 36, 96, 146, 248, 111, 108, 28, 224, 250, 129, 127, 105, 253, 218, 245, 145, 54, 56, 14, 0, 32, 16, 251, 101, 41, 118, 242, 171, 168, 93, 72, 182, 203, 58, 147, 83, 198, 5, 177, 68, 0, 122, 206, 102, 122 } });
        }
    }
}
