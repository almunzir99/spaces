using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addImageTableAndReplaceInArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 0, 48, 31, 804, DateTimeKind.Local).AddTicks(1983), new DateTime(2022, 6, 30, 0, 48, 31, 805, DateTimeKind.Local).AddTicks(4597), new byte[] { 238, 122, 209, 17, 212, 62, 234, 50, 191, 92, 96, 207, 159, 168, 55, 162, 89, 217, 41, 209, 193, 76, 72, 61, 174, 222, 91, 95, 240, 154, 213, 116, 111, 125, 195, 87, 203, 70, 38, 10, 183, 86, 168, 254, 77, 226, 7, 30, 97, 97, 57, 162, 164, 124, 75, 10, 152, 153, 23, 254, 239, 118, 90, 27 }, new byte[] { 66, 199, 39, 251, 24, 131, 217, 151, 16, 203, 156, 227, 68, 39, 241, 219, 106, 94, 198, 35, 147, 143, 22, 14, 182, 43, 58, 89, 195, 181, 232, 69, 31, 62, 68, 249, 221, 120, 13, 125, 37, 188, 82, 65, 132, 121, 245, 243, 17, 76, 235, 203, 141, 103, 249, 57, 40, 228, 236, 47, 131, 251, 27, 62, 56, 137, 54, 142, 194, 131, 118, 36, 41, 149, 99, 162, 92, 199, 211, 175, 137, 138, 224, 85, 127, 231, 27, 77, 245, 108, 143, 226, 117, 12, 0, 44, 197, 194, 130, 85, 159, 195, 24, 211, 22, 203, 37, 113, 145, 227, 135, 219, 14, 251, 209, 66, 32, 122, 36, 186, 65, 42, 153, 143, 84, 66, 221, 45 } });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ImageId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 0, 39, 50, 444, DateTimeKind.Local).AddTicks(1781), new DateTime(2022, 6, 30, 0, 39, 50, 445, DateTimeKind.Local).AddTicks(4184), new byte[] { 17, 205, 84, 84, 172, 255, 118, 155, 232, 213, 175, 7, 252, 85, 164, 135, 117, 129, 53, 138, 146, 0, 41, 84, 171, 234, 46, 153, 46, 201, 92, 153, 36, 152, 5, 53, 90, 211, 97, 212, 9, 9, 168, 228, 173, 209, 200, 193, 214, 184, 190, 63, 62, 232, 85, 221, 207, 37, 252, 129, 175, 210, 6, 18 }, new byte[] { 120, 86, 150, 250, 192, 119, 165, 227, 237, 161, 155, 232, 109, 221, 78, 102, 154, 24, 241, 219, 122, 127, 186, 46, 177, 5, 143, 133, 91, 180, 219, 213, 159, 182, 166, 32, 222, 246, 254, 73, 147, 150, 155, 55, 34, 152, 190, 27, 222, 84, 227, 115, 161, 239, 17, 199, 207, 36, 237, 81, 107, 249, 65, 227, 251, 27, 104, 250, 4, 37, 2, 16, 55, 147, 152, 19, 108, 172, 78, 26, 222, 226, 148, 146, 220, 122, 62, 61, 57, 155, 140, 138, 237, 209, 182, 7, 242, 25, 9, 181, 77, 219, 219, 201, 226, 187, 175, 77, 25, 158, 215, 76, 181, 250, 176, 146, 181, 208, 236, 172, 83, 90, 138, 169, 146, 51, 54, 178 } });
        }
    }
}
