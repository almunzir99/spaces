using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class fixArticleTranslationRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Articles_ArticleId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_ArticleId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ContentId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_SubtitleId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TitleId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Translations");

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubtitleId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContentId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranslationId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tags_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 0, 39, 50, 444, DateTimeKind.Local).AddTicks(1781), new DateTime(2022, 6, 30, 0, 39, 50, 445, DateTimeKind.Local).AddTicks(4184), new byte[] { 17, 205, 84, 84, 172, 255, 118, 155, 232, 213, 175, 7, 252, 85, 164, 135, 117, 129, 53, 138, 146, 0, 41, 84, 171, 234, 46, 153, 46, 201, 92, 153, 36, 152, 5, 53, 90, 211, 97, 212, 9, 9, 168, 228, 173, 209, 200, 193, 214, 184, 190, 63, 62, 232, 85, 221, 207, 37, 252, 129, 175, 210, 6, 18 }, new byte[] { 120, 86, 150, 250, 192, 119, 165, 227, 237, 161, 155, 232, 109, 221, 78, 102, 154, 24, 241, 219, 122, 127, 186, 46, 177, 5, 143, 133, 91, 180, 219, 213, 159, 182, 166, 32, 222, 246, 254, 73, 147, 150, 155, 55, 34, 152, 190, 27, 222, 84, 227, 115, 161, 239, 17, 199, 207, 36, 237, 81, 107, 249, 65, 227, 251, 27, 104, 250, 4, 37, 2, 16, 55, 147, 152, 19, 108, 172, 78, 26, 222, 226, 148, 146, 220, 122, 62, 61, 57, 155, 140, 138, 237, 209, 182, 7, 242, 25, 9, 181, 77, 219, 219, 201, 226, 187, 175, 77, 25, 158, 215, 76, 181, 250, 176, 146, 181, 208, 236, 172, 83, 90, 138, 169, 146, 51, 54, 178 } });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ContentId",
                table: "Articles",
                column: "ContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SubtitleId",
                table: "Articles",
                column: "SubtitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TitleId",
                table: "Articles",
                column: "TitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ArticleId",
                table: "Tags",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TranslationId",
                table: "Tags",
                column: "TranslationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ContentId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_SubtitleId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TitleId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Translations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                table: "Articles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubtitleId",
                table: "Articles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContentId",
                table: "Articles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 22, 51, 53, 406, DateTimeKind.Local).AddTicks(8075), new DateTime(2022, 6, 29, 22, 51, 53, 407, DateTimeKind.Local).AddTicks(9190), new byte[] { 92, 118, 77, 35, 207, 60, 7, 150, 220, 231, 160, 212, 123, 243, 80, 60, 162, 118, 236, 189, 16, 7, 133, 46, 19, 39, 33, 75, 127, 35, 128, 154, 74, 161, 106, 24, 131, 179, 137, 240, 5, 62, 119, 84, 131, 143, 11, 102, 157, 214, 246, 13, 69, 174, 241, 29, 108, 17, 111, 90, 244, 141, 43, 245 }, new byte[] { 41, 43, 184, 165, 123, 242, 82, 133, 29, 229, 99, 139, 30, 184, 107, 95, 102, 36, 246, 147, 36, 149, 111, 23, 119, 61, 218, 130, 15, 251, 79, 151, 35, 95, 52, 123, 1, 133, 77, 54, 58, 228, 220, 178, 104, 59, 70, 248, 15, 74, 20, 209, 34, 211, 223, 14, 94, 72, 82, 113, 1, 197, 96, 145, 199, 163, 56, 141, 78, 122, 26, 21, 151, 53, 145, 67, 75, 80, 76, 29, 83, 234, 210, 48, 244, 104, 199, 190, 189, 64, 104, 77, 55, 247, 176, 111, 154, 207, 151, 146, 115, 218, 27, 55, 162, 37, 108, 213, 47, 225, 89, 155, 208, 181, 91, 132, 189, 130, 17, 101, 167, 87, 150, 3, 10, 99, 5, 232 } });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_ArticleId",
                table: "Translations",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ContentId",
                table: "Articles",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SubtitleId",
                table: "Articles",
                column: "SubtitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TitleId",
                table: "Articles",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Articles_ArticleId",
                table: "Translations",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
