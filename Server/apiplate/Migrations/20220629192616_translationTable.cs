using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class translationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 21, 26, 15, 554, DateTimeKind.Local).AddTicks(3377), new DateTime(2022, 6, 29, 21, 26, 15, 555, DateTimeKind.Local).AddTicks(4347), new byte[] { 240, 200, 46, 71, 48, 140, 109, 78, 94, 249, 106, 37, 183, 95, 32, 110, 109, 228, 207, 254, 245, 143, 46, 242, 242, 13, 111, 32, 207, 230, 185, 9, 100, 22, 133, 57, 190, 210, 195, 106, 89, 156, 62, 117, 158, 226, 159, 55, 10, 231, 128, 59, 248, 245, 88, 101, 108, 169, 43, 235, 152, 164, 152, 174 }, new byte[] { 160, 181, 216, 223, 212, 23, 155, 204, 114, 157, 161, 73, 8, 176, 113, 200, 10, 25, 202, 74, 36, 59, 136, 209, 48, 107, 71, 11, 103, 188, 197, 9, 228, 190, 187, 251, 92, 216, 108, 184, 176, 181, 164, 60, 68, 167, 156, 215, 37, 60, 27, 233, 218, 32, 141, 141, 23, 78, 214, 194, 141, 108, 218, 25, 164, 233, 120, 251, 196, 201, 42, 161, 191, 148, 87, 50, 174, 186, 45, 0, 86, 129, 31, 239, 99, 190, 84, 53, 79, 44, 33, 12, 141, 131, 95, 91, 32, 82, 140, 197, 219, 207, 194, 202, 212, 72, 115, 126, 228, 102, 82, 16, 133, 145, 171, 179, 179, 159, 87, 172, 26, 202, 255, 220, 91, 58, 236, 166 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 7, 23, 1, 29, 171, DateTimeKind.Local).AddTicks(2305), new DateTime(2022, 6, 7, 23, 1, 29, 172, DateTimeKind.Local).AddTicks(2586), new byte[] { 155, 237, 118, 70, 202, 176, 246, 102, 103, 193, 107, 250, 59, 105, 158, 28, 47, 47, 145, 162, 212, 36, 84, 142, 6, 70, 113, 217, 164, 15, 244, 92, 29, 103, 76, 77, 179, 196, 190, 174, 63, 92, 111, 155, 18, 130, 156, 209, 92, 1, 42, 183, 115, 146, 202, 195, 53, 24, 239, 217, 159, 61, 236, 90 }, new byte[] { 127, 26, 190, 83, 82, 216, 45, 188, 199, 132, 160, 82, 205, 222, 64, 220, 34, 116, 249, 159, 64, 118, 147, 95, 33, 62, 36, 53, 83, 117, 159, 69, 132, 142, 82, 63, 160, 176, 189, 7, 246, 196, 90, 67, 158, 63, 78, 109, 253, 5, 98, 249, 213, 187, 117, 162, 9, 65, 238, 24, 196, 193, 107, 133, 30, 7, 126, 254, 134, 1, 23, 28, 41, 166, 98, 63, 94, 58, 242, 107, 183, 16, 219, 92, 4, 171, 103, 51, 0, 172, 141, 225, 122, 79, 226, 49, 73, 120, 172, 30, 246, 104, 52, 227, 36, 89, 164, 166, 178, 45, 137, 153, 197, 212, 30, 130, 35, 103, 118, 17, 67, 112, 37, 97, 112, 70, 101, 151 } });
        }
    }
}
