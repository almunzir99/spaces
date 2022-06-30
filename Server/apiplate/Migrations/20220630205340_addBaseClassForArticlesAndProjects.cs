using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addBaseClassForArticlesAndProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Regions_RegionId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sectors_SectorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Translations_ContentId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Translations_SubtitleId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Translations_TitleId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Articles_ArticleId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "ArticleBase");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Tags",
                newName: "ArticleBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ArticleId",
                table: "Tags",
                newName: "IX_Tags_ArticleBaseId");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Comments",
                newName: "ArticleBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                newName: "IX_Comments_ArticleBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_TitleId",
                table: "ArticleBase",
                newName: "IX_ArticleBase_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_SubtitleId",
                table: "ArticleBase",
                newName: "IX_ArticleBase_SubtitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_SectorId",
                table: "ArticleBase",
                newName: "IX_ArticleBase_SectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_RegionId",
                table: "ArticleBase",
                newName: "IX_ArticleBase_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_ImageId",
                table: "ArticleBase",
                newName: "IX_ArticleBase_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_ContentId",
                table: "ArticleBase",
                newName: "IX_ArticleBase_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_AuthorId",
                table: "ArticleBase",
                newName: "IX_ArticleBase_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleBase",
                table: "ArticleBase",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 22, 53, 40, 156, DateTimeKind.Local).AddTicks(7370), new DateTime(2022, 6, 30, 22, 53, 40, 157, DateTimeKind.Local).AddTicks(7715), new byte[] { 155, 251, 239, 206, 199, 191, 239, 83, 80, 103, 135, 199, 200, 96, 190, 254, 47, 212, 2, 55, 169, 5, 238, 248, 65, 245, 29, 11, 92, 48, 229, 152, 27, 15, 170, 103, 131, 222, 145, 197, 43, 103, 36, 233, 85, 92, 182, 47, 49, 87, 244, 219, 107, 143, 102, 102, 187, 255, 62, 62, 47, 127, 21, 214 }, new byte[] { 52, 161, 135, 203, 17, 27, 25, 239, 230, 51, 193, 25, 179, 166, 167, 11, 99, 140, 38, 135, 200, 57, 150, 35, 71, 51, 142, 179, 80, 213, 76, 80, 82, 81, 184, 40, 212, 183, 77, 182, 26, 201, 10, 118, 130, 11, 3, 51, 139, 128, 238, 58, 171, 98, 169, 99, 124, 179, 234, 124, 202, 159, 134, 51, 12, 219, 157, 70, 253, 121, 195, 126, 207, 242, 162, 162, 226, 2, 227, 105, 2, 252, 127, 90, 99, 208, 65, 106, 32, 9, 151, 239, 7, 88, 82, 187, 213, 215, 230, 128, 251, 211, 118, 197, 0, 49, 172, 22, 167, 229, 30, 235, 245, 165, 121, 180, 248, 88, 72, 198, 55, 93, 94, 162, 206, 76, 211, 26 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBase_Images_ImageId",
                table: "ArticleBase",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBase_Regions_RegionId",
                table: "ArticleBase",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBase_Sectors_SectorId",
                table: "ArticleBase",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBase_Translations_ContentId",
                table: "ArticleBase",
                column: "ContentId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBase_Translations_SubtitleId",
                table: "ArticleBase",
                column: "SubtitleId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBase_Translations_TitleId",
                table: "ArticleBase",
                column: "TitleId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBase_Users_AuthorId",
                table: "ArticleBase",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ArticleBase_ArticleBaseId",
                table: "Comments",
                column: "ArticleBaseId",
                principalTable: "ArticleBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_ArticleBase_ArticleBaseId",
                table: "Tags",
                column: "ArticleBaseId",
                principalTable: "ArticleBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBase_Images_ImageId",
                table: "ArticleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBase_Regions_RegionId",
                table: "ArticleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBase_Sectors_SectorId",
                table: "ArticleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBase_Translations_ContentId",
                table: "ArticleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBase_Translations_SubtitleId",
                table: "ArticleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBase_Translations_TitleId",
                table: "ArticleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBase_Users_AuthorId",
                table: "ArticleBase");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ArticleBase_ArticleBaseId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_ArticleBase_ArticleBaseId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleBase",
                table: "ArticleBase");

            migrationBuilder.RenameTable(
                name: "ArticleBase",
                newName: "Articles");

            migrationBuilder.RenameColumn(
                name: "ArticleBaseId",
                table: "Tags",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ArticleBaseId",
                table: "Tags",
                newName: "IX_Tags_ArticleId");

            migrationBuilder.RenameColumn(
                name: "ArticleBaseId",
                table: "Comments",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleBaseId",
                table: "Comments",
                newName: "IX_Comments_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleBase_TitleId",
                table: "Articles",
                newName: "IX_Articles_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleBase_SubtitleId",
                table: "Articles",
                newName: "IX_Articles_SubtitleId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleBase_SectorId",
                table: "Articles",
                newName: "IX_Articles_SectorId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleBase_RegionId",
                table: "Articles",
                newName: "IX_Articles_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleBase_ImageId",
                table: "Articles",
                newName: "IX_Articles_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleBase_ContentId",
                table: "Articles",
                newName: "IX_Articles_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleBase_AuthorId",
                table: "Articles",
                newName: "IX_Articles_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 17, 24, 8, 161, DateTimeKind.Local).AddTicks(6556), new DateTime(2022, 6, 30, 17, 24, 8, 162, DateTimeKind.Local).AddTicks(6879), new byte[] { 179, 118, 142, 175, 255, 17, 129, 83, 49, 101, 90, 20, 139, 144, 44, 20, 47, 54, 208, 73, 30, 75, 251, 208, 54, 39, 181, 76, 11, 160, 71, 224, 234, 77, 238, 171, 169, 126, 170, 144, 178, 37, 25, 38, 110, 145, 238, 125, 68, 186, 91, 161, 5, 237, 122, 97, 74, 138, 221, 5, 245, 156, 8, 81 }, new byte[] { 66, 89, 150, 138, 231, 143, 252, 104, 34, 180, 135, 0, 84, 210, 106, 108, 115, 122, 144, 131, 161, 9, 178, 219, 7, 13, 98, 62, 174, 40, 21, 126, 29, 250, 215, 133, 144, 163, 196, 111, 38, 209, 146, 170, 133, 41, 254, 3, 155, 234, 119, 14, 103, 180, 12, 145, 247, 48, 72, 210, 128, 128, 191, 129, 141, 144, 120, 156, 231, 101, 194, 161, 143, 148, 136, 168, 9, 255, 167, 170, 83, 123, 216, 155, 137, 116, 32, 220, 243, 39, 129, 71, 193, 15, 68, 55, 148, 226, 36, 198, 155, 120, 195, 161, 240, 45, 150, 5, 99, 237, 200, 158, 87, 178, 110, 94, 14, 28, 142, 208, 85, 190, 244, 136, 9, 185, 133, 62 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Translations_ContentId",
                table: "Articles",
                column: "ContentId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Translations_SubtitleId",
                table: "Articles",
                column: "SubtitleId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Translations_TitleId",
                table: "Articles",
                column: "TitleId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Articles_ArticleId",
                table: "Tags",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
