using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addRegionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    DescriptionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Translations_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regions_Translations_TitleId",
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
                values: new object[] { new DateTime(2022, 6, 30, 8, 43, 23, 62, DateTimeKind.Local).AddTicks(692), new DateTime(2022, 6, 30, 8, 43, 23, 63, DateTimeKind.Local).AddTicks(2125), new byte[] { 35, 197, 150, 248, 156, 121, 162, 222, 164, 193, 179, 191, 43, 174, 187, 160, 243, 141, 19, 140, 203, 129, 101, 82, 51, 200, 61, 246, 57, 126, 126, 208, 59, 67, 11, 47, 191, 99, 149, 249, 9, 58, 233, 173, 181, 240, 53, 163, 86, 190, 60, 92, 142, 240, 119, 105, 169, 184, 120, 75, 120, 236, 238, 251 }, new byte[] { 50, 62, 82, 0, 213, 173, 16, 84, 181, 90, 219, 91, 181, 42, 172, 73, 98, 125, 81, 219, 176, 62, 84, 184, 105, 60, 157, 187, 120, 230, 112, 42, 4, 251, 150, 44, 124, 80, 136, 255, 57, 102, 94, 19, 41, 155, 107, 134, 159, 55, 132, 85, 140, 199, 163, 204, 97, 44, 82, 159, 97, 178, 26, 213, 94, 251, 1, 96, 181, 171, 218, 115, 159, 8, 83, 10, 119, 204, 51, 237, 144, 37, 136, 36, 96, 146, 248, 111, 108, 28, 224, 250, 129, 127, 105, 253, 218, 245, 145, 54, 56, 14, 0, 32, 16, 251, 101, 41, 118, 242, 171, 168, 93, 72, 182, 203, 58, 147, 83, 198, 5, 177, 68, 0, 122, 206, 102, 122 } });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_DescriptionId",
                table: "Regions",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_TitleId",
                table: "Regions",
                column: "TitleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 1, 28, 16, 166, DateTimeKind.Local).AddTicks(2606), new DateTime(2022, 6, 30, 1, 28, 16, 167, DateTimeKind.Local).AddTicks(9098), new byte[] { 47, 65, 238, 80, 182, 233, 51, 68, 182, 177, 215, 103, 166, 137, 210, 99, 16, 91, 103, 177, 190, 15, 144, 125, 234, 88, 136, 252, 47, 96, 122, 51, 127, 183, 130, 86, 216, 34, 72, 105, 183, 162, 217, 227, 199, 79, 21, 226, 211, 218, 126, 232, 251, 24, 143, 188, 128, 114, 165, 100, 95, 145, 157, 191 }, new byte[] { 205, 97, 244, 42, 104, 54, 165, 23, 208, 167, 110, 79, 243, 31, 42, 219, 74, 82, 182, 1, 100, 76, 233, 165, 61, 155, 87, 85, 113, 107, 26, 50, 69, 122, 181, 106, 130, 110, 241, 106, 109, 167, 253, 203, 190, 168, 173, 231, 67, 82, 191, 191, 37, 251, 65, 104, 175, 21, 75, 48, 230, 197, 9, 32, 91, 250, 66, 105, 80, 177, 58, 149, 184, 12, 69, 173, 1, 143, 82, 83, 7, 190, 87, 235, 150, 250, 209, 111, 146, 79, 153, 135, 156, 7, 185, 123, 197, 229, 118, 252, 38, 139, 173, 172, 124, 90, 144, 58, 151, 218, 100, 211, 79, 201, 55, 150, 156, 138, 92, 236, 200, 105, 50, 144, 124, 246, 162, 219 } });
        }
    }
}
