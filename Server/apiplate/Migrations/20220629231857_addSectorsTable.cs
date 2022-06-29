using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addSectorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    DescriptionId = table.Column<int>(type: "int", nullable: false),
                    IconId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sectors_Images_IconId",
                        column: x => x.IconId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sectors_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sectors_Translations_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sectors_Translations_TitleId",
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
                values: new object[] { new DateTime(2022, 6, 30, 1, 18, 56, 190, DateTimeKind.Local).AddTicks(3672), new DateTime(2022, 6, 30, 1, 18, 56, 191, DateTimeKind.Local).AddTicks(5052), new byte[] { 48, 126, 64, 183, 200, 162, 117, 83, 175, 8, 244, 102, 176, 15, 138, 67, 81, 177, 212, 237, 249, 115, 108, 174, 185, 99, 115, 141, 15, 72, 11, 103, 43, 232, 219, 16, 113, 140, 84, 165, 76, 37, 45, 63, 241, 96, 212, 153, 147, 65, 218, 139, 39, 27, 51, 89, 44, 223, 155, 214, 206, 78, 26, 243 }, new byte[] { 182, 117, 53, 152, 175, 182, 196, 69, 197, 94, 34, 194, 222, 160, 177, 32, 179, 196, 108, 148, 167, 191, 124, 149, 137, 141, 53, 91, 145, 32, 236, 25, 141, 159, 182, 42, 8, 15, 57, 224, 229, 202, 32, 221, 160, 25, 99, 153, 61, 132, 59, 10, 250, 218, 252, 145, 129, 212, 252, 199, 83, 172, 53, 102, 227, 222, 95, 243, 238, 194, 16, 137, 234, 86, 182, 154, 189, 243, 224, 234, 81, 162, 136, 45, 194, 245, 230, 136, 238, 48, 255, 67, 131, 126, 131, 48, 182, 80, 206, 101, 158, 219, 240, 46, 160, 12, 132, 201, 108, 200, 187, 119, 124, 89, 255, 89, 158, 13, 51, 19, 48, 1, 91, 96, 187, 186, 28, 3 } });

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_DescriptionId",
                table: "Sectors",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_IconId",
                table: "Sectors",
                column: "IconId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_ImageId",
                table: "Sectors",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_TitleId",
                table: "Sectors",
                column: "TitleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 0, 48, 31, 804, DateTimeKind.Local).AddTicks(1983), new DateTime(2022, 6, 30, 0, 48, 31, 805, DateTimeKind.Local).AddTicks(4597), new byte[] { 238, 122, 209, 17, 212, 62, 234, 50, 191, 92, 96, 207, 159, 168, 55, 162, 89, 217, 41, 209, 193, 76, 72, 61, 174, 222, 91, 95, 240, 154, 213, 116, 111, 125, 195, 87, 203, 70, 38, 10, 183, 86, 168, 254, 77, 226, 7, 30, 97, 97, 57, 162, 164, 124, 75, 10, 152, 153, 23, 254, 239, 118, 90, 27 }, new byte[] { 66, 199, 39, 251, 24, 131, 217, 151, 16, 203, 156, 227, 68, 39, 241, 219, 106, 94, 198, 35, 147, 143, 22, 14, 182, 43, 58, 89, 195, 181, 232, 69, 31, 62, 68, 249, 221, 120, 13, 125, 37, 188, 82, 65, 132, 121, 245, 243, 17, 76, 235, 203, 141, 103, 249, 57, 40, 228, 236, 47, 131, 251, 27, 62, 56, 137, 54, 142, 194, 131, 118, 36, 41, 149, 99, 162, 92, 199, 211, 175, 137, 138, 224, 85, 127, 231, 27, 77, 245, 108, 143, 226, 117, 12, 0, 44, 197, 194, 130, 85, 159, 195, 24, 211, 22, 203, 37, 113, 145, 227, 135, 219, 14, 251, 209, 66, 32, 122, 36, 186, 65, 42, 153, 143, 84, 66, 221, 45 } });
        }
    }
}
