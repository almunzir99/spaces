using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 17, 10, 31, 117, DateTimeKind.Local).AddTicks(6230), new DateTime(2022, 6, 30, 17, 10, 31, 118, DateTimeKind.Local).AddTicks(7721), new byte[] { 85, 140, 81, 147, 132, 118, 29, 64, 135, 187, 129, 196, 185, 29, 162, 199, 42, 213, 245, 87, 202, 108, 102, 82, 77, 127, 115, 10, 196, 17, 241, 168, 6, 220, 108, 26, 248, 221, 47, 127, 90, 239, 188, 251, 217, 120, 112, 149, 165, 120, 100, 185, 210, 65, 24, 238, 218, 123, 246, 64, 237, 48, 251, 84 }, new byte[] { 101, 23, 100, 197, 141, 233, 199, 24, 255, 178, 241, 190, 217, 48, 11, 173, 185, 208, 155, 140, 9, 76, 17, 0, 211, 127, 137, 239, 43, 7, 241, 172, 4, 139, 90, 146, 76, 3, 222, 85, 36, 39, 26, 178, 200, 177, 184, 149, 194, 183, 84, 18, 122, 172, 47, 210, 132, 87, 66, 42, 195, 105, 3, 236, 94, 119, 59, 174, 66, 145, 194, 30, 39, 93, 82, 134, 168, 55, 224, 91, 179, 209, 251, 178, 27, 111, 238, 148, 235, 232, 125, 198, 50, 55, 131, 122, 93, 3, 51, 208, 134, 111, 121, 220, 203, 167, 28, 97, 153, 155, 150, 219, 85, 10, 224, 167, 32, 28, 189, 13, 116, 174, 55, 201, 121, 120, 186, 103 } });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_RegionId",
                table: "Articles",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SectorId",
                table: "Articles",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Regions_RegionId",
                table: "Articles",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sectors_SectorId",
                table: "Articles",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Regions_RegionId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sectors_SectorId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_RegionId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_SectorId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 16, 38, 24, 996, DateTimeKind.Local).AddTicks(9994), new DateTime(2022, 6, 30, 16, 38, 24, 998, DateTimeKind.Local).AddTicks(341), new byte[] { 52, 38, 102, 232, 133, 97, 208, 240, 122, 202, 17, 98, 197, 42, 201, 238, 159, 61, 42, 80, 83, 3, 48, 228, 16, 130, 150, 16, 213, 86, 166, 222, 161, 76, 250, 12, 77, 197, 22, 46, 248, 73, 4, 1, 173, 126, 141, 138, 164, 203, 36, 27, 130, 196, 20, 71, 138, 226, 92, 195, 30, 35, 33, 122 }, new byte[] { 6, 27, 212, 172, 65, 214, 157, 170, 97, 28, 60, 156, 245, 84, 101, 79, 144, 86, 60, 155, 136, 93, 43, 120, 23, 119, 163, 3, 236, 131, 80, 175, 247, 173, 11, 106, 135, 131, 247, 151, 189, 37, 171, 132, 227, 208, 117, 196, 140, 175, 120, 8, 166, 123, 147, 50, 144, 107, 251, 2, 249, 0, 133, 201, 214, 225, 184, 192, 56, 160, 10, 213, 105, 0, 3, 59, 187, 27, 156, 93, 244, 166, 87, 244, 176, 44, 75, 221, 3, 128, 83, 176, 123, 191, 126, 50, 24, 232, 162, 35, 70, 211, 215, 76, 160, 236, 204, 131, 137, 101, 8, 93, 26, 89, 33, 77, 128, 143, 210, 199, 34, 144, 52, 47, 254, 76, 243, 195 } });
        }
    }
}
