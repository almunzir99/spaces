using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addPartnersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", nullable: false),
                    LogoId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Images_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partners_Translations_NameId",
                        column: x => x.NameId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 16, 3, 33, 660, DateTimeKind.Local).AddTicks(5548), new DateTime(2022, 6, 30, 16, 3, 33, 662, DateTimeKind.Local).AddTicks(1584), new byte[] { 88, 112, 211, 235, 203, 201, 192, 243, 179, 137, 144, 23, 91, 35, 234, 47, 233, 95, 171, 54, 246, 167, 3, 7, 251, 110, 244, 192, 177, 15, 228, 94, 6, 97, 17, 103, 104, 26, 44, 55, 212, 153, 241, 18, 127, 125, 200, 214, 152, 154, 201, 106, 246, 1, 239, 28, 122, 143, 106, 104, 154, 139, 194, 47 }, new byte[] { 197, 27, 172, 17, 20, 27, 4, 198, 2, 7, 41, 84, 137, 134, 73, 72, 59, 140, 172, 4, 174, 240, 113, 243, 189, 13, 118, 68, 21, 250, 217, 19, 186, 102, 113, 178, 151, 161, 40, 28, 230, 254, 242, 16, 246, 236, 253, 106, 51, 209, 60, 148, 218, 247, 253, 236, 162, 137, 245, 172, 245, 16, 30, 113, 211, 37, 87, 50, 8, 52, 52, 215, 252, 51, 42, 253, 187, 96, 12, 121, 10, 39, 177, 217, 158, 209, 109, 93, 99, 15, 26, 199, 162, 241, 133, 82, 175, 95, 193, 233, 206, 149, 237, 44, 233, 119, 24, 62, 220, 39, 71, 239, 10, 244, 231, 211, 169, 151, 247, 230, 98, 190, 134, 244, 120, 65, 54, 37 } });

            migrationBuilder.CreateIndex(
                name: "IX_Partners_LogoId",
                table: "Partners",
                column: "LogoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_NameId",
                table: "Partners",
                column: "NameId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 55, 27, 188, DateTimeKind.Local).AddTicks(727), new DateTime(2022, 6, 30, 15, 55, 27, 189, DateTimeKind.Local).AddTicks(957), new byte[] { 22, 216, 86, 17, 93, 87, 221, 44, 249, 230, 173, 46, 207, 75, 103, 190, 230, 74, 36, 177, 112, 54, 83, 13, 200, 251, 140, 149, 97, 174, 98, 254, 134, 127, 98, 134, 156, 23, 54, 3, 198, 247, 139, 155, 76, 137, 148, 224, 40, 17, 148, 164, 239, 65, 91, 122, 0, 221, 52, 86, 1, 50, 139, 17 }, new byte[] { 159, 149, 224, 151, 92, 158, 49, 216, 94, 162, 66, 247, 64, 211, 103, 133, 40, 71, 88, 91, 181, 180, 66, 184, 63, 254, 99, 7, 236, 22, 58, 44, 147, 163, 232, 222, 211, 188, 27, 57, 222, 27, 227, 161, 148, 84, 76, 4, 240, 38, 55, 182, 151, 43, 249, 149, 125, 57, 227, 190, 149, 68, 155, 188, 181, 53, 224, 210, 138, 116, 203, 110, 177, 251, 88, 83, 204, 88, 162, 55, 9, 0, 138, 131, 187, 235, 109, 251, 100, 217, 107, 148, 65, 160, 176, 222, 173, 4, 96, 193, 113, 158, 219, 147, 141, 37, 26, 181, 75, 151, 212, 103, 0, 185, 238, 100, 226, 61, 137, 8, 163, 127, 215, 230, 244, 11, 115, 88 } });
        }
    }
}
