using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addSlidersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlidersPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    SubtitleId = table.Column<int>(type: "int", nullable: false),
                    DescriptionId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sliders_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sliders_Translations_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sliders_Translations_SubtitleId",
                        column: x => x.SubtitleId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sliders_Translations_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 20, 21, 268, DateTimeKind.Local).AddTicks(747), new DateTime(2022, 6, 30, 10, 20, 21, 269, DateTimeKind.Local).AddTicks(8323), new byte[] { 91, 157, 6, 156, 107, 190, 168, 58, 94, 59, 156, 44, 94, 181, 173, 64, 223, 172, 94, 80, 158, 35, 97, 1, 29, 38, 157, 71, 213, 236, 26, 137, 62, 158, 56, 143, 165, 227, 187, 9, 49, 137, 125, 52, 222, 116, 228, 88, 227, 212, 57, 254, 219, 226, 162, 254, 155, 209, 196, 95, 238, 25, 74, 181 }, new byte[] { 220, 143, 225, 13, 188, 169, 208, 157, 86, 86, 143, 231, 155, 198, 196, 227, 180, 9, 241, 191, 124, 101, 233, 67, 24, 64, 4, 97, 72, 49, 148, 48, 120, 145, 157, 209, 54, 114, 118, 184, 39, 169, 27, 77, 162, 25, 106, 50, 218, 159, 199, 46, 220, 42, 178, 238, 255, 32, 192, 174, 117, 97, 28, 10, 87, 36, 93, 105, 199, 78, 183, 43, 218, 105, 121, 187, 195, 166, 10, 92, 38, 202, 51, 244, 211, 222, 111, 56, 0, 175, 42, 137, 144, 87, 86, 95, 220, 179, 18, 102, 29, 192, 120, 17, 66, 9, 85, 237, 177, 28, 84, 228, 17, 77, 27, 58, 199, 144, 254, 106, 83, 198, 214, 221, 29, 112, 116, 52 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_SlidersPermissionsId",
                table: "Roles",
                column: "SlidersPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_DescriptionId",
                table: "Sliders",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_ImageId",
                table: "Sliders",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_SubtitleId",
                table: "Sliders",
                column: "SubtitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_TitleId",
                table: "Sliders",
                column: "TitleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_SlidersPermissionsId",
                table: "Roles",
                column: "SlidersPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_SlidersPermissionsId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_Roles_SlidersPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SlidersPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 8, 58, 16, 740, DateTimeKind.Local).AddTicks(8977), new DateTime(2022, 6, 30, 8, 58, 16, 742, DateTimeKind.Local).AddTicks(8308), new byte[] { 117, 53, 82, 94, 89, 111, 66, 65, 86, 22, 253, 156, 216, 41, 46, 53, 40, 159, 148, 4, 166, 25, 5, 204, 213, 220, 216, 228, 1, 115, 55, 189, 1, 61, 12, 214, 28, 77, 231, 7, 8, 40, 70, 41, 29, 202, 122, 229, 115, 97, 22, 120, 187, 244, 76, 59, 130, 37, 200, 160, 138, 147, 110, 253 }, new byte[] { 110, 102, 175, 59, 14, 139, 196, 13, 82, 163, 162, 30, 113, 83, 76, 99, 49, 93, 59, 190, 80, 131, 51, 144, 213, 230, 247, 6, 37, 136, 106, 157, 12, 140, 85, 140, 63, 34, 19, 242, 92, 133, 190, 70, 71, 66, 116, 116, 78, 240, 172, 53, 71, 241, 72, 178, 64, 176, 158, 189, 69, 85, 58, 153, 124, 130, 139, 156, 179, 109, 65, 252, 146, 100, 130, 101, 84, 243, 140, 143, 216, 23, 10, 21, 61, 220, 244, 2, 33, 87, 127, 35, 149, 9, 21, 77, 44, 149, 69, 198, 206, 47, 209, 120, 207, 71, 93, 15, 178, 162, 47, 85, 134, 224, 55, 91, 82, 232, 17, 126, 93, 74, 242, 141, 197, 41, 238, 252 } });
        }
    }
}
