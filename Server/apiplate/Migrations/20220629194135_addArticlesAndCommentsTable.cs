using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addArticlesAndCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Translations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    SubtitleId = table.Column<int>(type: "int", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Translations_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Translations_SubtitleId",
                        column: x => x.SubtitleId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Translations_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 21, 41, 34, 60, DateTimeKind.Local).AddTicks(9002), new DateTime(2022, 6, 29, 21, 41, 34, 61, DateTimeKind.Local).AddTicks(9920), new byte[] { 41, 90, 30, 102, 183, 76, 249, 39, 171, 108, 222, 169, 70, 9, 30, 189, 226, 178, 145, 55, 5, 96, 185, 238, 23, 155, 225, 233, 228, 179, 206, 41, 164, 99, 125, 239, 112, 188, 64, 57, 96, 55, 220, 255, 98, 154, 119, 156, 15, 179, 212, 163, 106, 120, 21, 140, 32, 176, 39, 243, 18, 30, 62, 110 }, new byte[] { 152, 192, 114, 116, 72, 14, 211, 22, 75, 85, 199, 148, 194, 16, 112, 146, 241, 39, 93, 144, 90, 246, 252, 30, 163, 205, 117, 73, 119, 28, 194, 52, 66, 217, 113, 15, 160, 97, 60, 1, 177, 150, 39, 105, 65, 189, 167, 109, 62, 71, 158, 16, 146, 3, 72, 179, 211, 141, 239, 142, 195, 120, 174, 182, 174, 186, 85, 254, 255, 196, 213, 240, 60, 253, 117, 28, 73, 222, 138, 162, 173, 136, 21, 52, 102, 251, 145, 231, 40, 71, 132, 7, 198, 31, 7, 70, 63, 212, 40, 17, 97, 10, 202, 32, 153, 85, 78, 210, 140, 232, 252, 36, 24, 127, 86, 32, 31, 2, 150, 147, 175, 40, 240, 109, 218, 108, 155, 147 } });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_ArticleId",
                table: "Translations",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Articles_ArticleId",
                table: "Translations",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Articles_ArticleId",
                table: "Translations");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Translations_ArticleId",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Translations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 29, 21, 26, 15, 554, DateTimeKind.Local).AddTicks(3377), new DateTime(2022, 6, 29, 21, 26, 15, 555, DateTimeKind.Local).AddTicks(4347), new byte[] { 240, 200, 46, 71, 48, 140, 109, 78, 94, 249, 106, 37, 183, 95, 32, 110, 109, 228, 207, 254, 245, 143, 46, 242, 242, 13, 111, 32, 207, 230, 185, 9, 100, 22, 133, 57, 190, 210, 195, 106, 89, 156, 62, 117, 158, 226, 159, 55, 10, 231, 128, 59, 248, 245, 88, 101, 108, 169, 43, 235, 152, 164, 152, 174 }, new byte[] { 160, 181, 216, 223, 212, 23, 155, 204, 114, 157, 161, 73, 8, 176, 113, 200, 10, 25, 202, 74, 36, 59, 136, 209, 48, 107, 71, 11, 103, 188, 197, 9, 228, 190, 187, 251, 92, 216, 108, 184, 176, 181, 164, 60, 68, 167, 156, 215, 37, 60, 27, 233, 218, 32, 141, 141, 23, 78, 214, 194, 141, 108, 218, 25, 164, 233, 120, 251, 196, 201, 42, 161, 191, 148, 87, 50, 174, 186, 45, 0, 86, 129, 31, 239, 99, 190, 84, 53, 79, 44, 33, 12, 141, 131, 95, 91, 32, 82, 140, 197, 219, 207, 194, 202, 212, 72, 115, 126, 228, 102, 82, 16, 133, 145, 171, 179, 179, 159, 87, 172, 26, 202, 255, 220, 91, 58, 236, 166 } });
        }
    }
}
