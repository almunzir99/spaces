using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class mediaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThumbnailId = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainVideo = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Images_ThumbnailId",
                        column: x => x.ThumbnailId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 8, 21, 23, 1, 936, DateTimeKind.Local).AddTicks(5629), new DateTime(2022, 7, 8, 21, 23, 1, 938, DateTimeKind.Local).AddTicks(6829), new byte[] { 148, 83, 139, 105, 230, 255, 33, 237, 102, 222, 95, 44, 80, 108, 167, 108, 242, 135, 178, 43, 46, 16, 16, 119, 213, 255, 162, 196, 156, 191, 59, 19, 127, 1, 232, 81, 251, 72, 110, 81, 249, 240, 103, 83, 141, 10, 85, 17, 1, 175, 157, 219, 70, 150, 245, 128, 121, 82, 222, 9, 131, 240, 207, 35 }, new byte[] { 66, 134, 3, 95, 239, 23, 76, 32, 184, 70, 209, 47, 203, 180, 48, 167, 30, 229, 117, 212, 177, 51, 240, 80, 5, 33, 9, 222, 185, 164, 244, 247, 134, 128, 238, 40, 98, 64, 39, 146, 196, 94, 27, 100, 255, 174, 147, 130, 189, 179, 214, 158, 93, 217, 17, 232, 241, 236, 40, 92, 69, 232, 234, 101, 180, 35, 167, 14, 205, 202, 247, 236, 54, 119, 15, 35, 184, 120, 190, 98, 171, 9, 206, 59, 168, 152, 223, 213, 177, 220, 138, 45, 34, 59, 1, 62, 191, 24, 215, 137, 152, 66, 229, 170, 80, 132, 199, 206, 157, 7, 167, 97, 184, 129, 192, 142, 73, 158, 226, 133, 184, 118, 253, 153, 199, 252, 243, 152 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_MediaPermissionsId",
                table: "Roles",
                column: "MediaPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_ThumbnailId",
                table: "Media",
                column: "ThumbnailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_MediaPermissionsId",
                table: "Roles",
                column: "MediaPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_MediaPermissionsId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Roles_MediaPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MediaPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 3, 17, 33, 38, 559, DateTimeKind.Local).AddTicks(6920), new DateTime(2022, 7, 3, 17, 33, 38, 560, DateTimeKind.Local).AddTicks(7491), new byte[] { 57, 174, 130, 157, 123, 107, 98, 27, 171, 152, 71, 108, 116, 99, 198, 16, 40, 106, 87, 204, 66, 241, 68, 138, 70, 15, 178, 129, 164, 218, 59, 92, 142, 96, 171, 229, 140, 167, 138, 133, 247, 218, 57, 171, 135, 196, 195, 92, 73, 87, 2, 222, 183, 98, 85, 20, 64, 127, 9, 242, 63, 252, 83, 146 }, new byte[] { 14, 33, 235, 158, 86, 182, 220, 142, 245, 202, 153, 167, 81, 243, 89, 160, 145, 241, 128, 39, 15, 50, 181, 82, 187, 228, 139, 160, 114, 52, 146, 107, 77, 188, 5, 70, 77, 152, 36, 58, 45, 230, 73, 241, 128, 92, 192, 129, 9, 141, 35, 91, 6, 239, 243, 107, 213, 164, 31, 171, 159, 22, 229, 8, 156, 213, 228, 58, 195, 130, 182, 61, 45, 208, 58, 176, 195, 77, 66, 218, 64, 87, 212, 103, 62, 93, 210, 141, 120, 255, 206, 213, 2, 177, 59, 45, 246, 198, 31, 198, 52, 235, 32, 45, 25, 121, 118, 193, 191, 106, 111, 139, 100, 215, 219, 203, 86, 191, 210, 255, 238, 149, 244, 180, 248, 215, 231, 44 } });
        }
    }
}
