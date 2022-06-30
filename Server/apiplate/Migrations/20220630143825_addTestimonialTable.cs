using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addTestimonialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestimonialsPermissionsId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testimonials_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Testimonials_Translations_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Testimonials_Translations_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Testimonials_Translations_JobId",
                        column: x => x.JobId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 16, 38, 24, 996, DateTimeKind.Local).AddTicks(9994), new DateTime(2022, 6, 30, 16, 38, 24, 998, DateTimeKind.Local).AddTicks(341), new byte[] { 52, 38, 102, 232, 133, 97, 208, 240, 122, 202, 17, 98, 197, 42, 201, 238, 159, 61, 42, 80, 83, 3, 48, 228, 16, 130, 150, 16, 213, 86, 166, 222, 161, 76, 250, 12, 77, 197, 22, 46, 248, 73, 4, 1, 173, 126, 141, 138, 164, 203, 36, 27, 130, 196, 20, 71, 138, 226, 92, 195, 30, 35, 33, 122 }, new byte[] { 6, 27, 212, 172, 65, 214, 157, 170, 97, 28, 60, 156, 245, 84, 101, 79, 144, 86, 60, 155, 136, 93, 43, 120, 23, 119, 163, 3, 236, 131, 80, 175, 247, 173, 11, 106, 135, 131, 247, 151, 189, 37, 171, 132, 227, 208, 117, 196, 140, 175, 120, 8, 166, 123, 147, 50, 144, 107, 251, 2, 249, 0, 133, 201, 214, 225, 184, 192, 56, 160, 10, 213, 105, 0, 3, 59, 187, 27, 156, 93, 244, 166, 87, 244, 176, 44, 75, 221, 3, 128, 83, 176, 123, 191, 126, 50, 24, 232, 162, 35, 70, 211, 215, 76, 160, 236, 204, 131, 137, 101, 8, 93, 26, 89, 33, 77, 128, 143, 210, 199, 34, 144, 52, 47, 254, 76, 243, 195 } });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_TestimonialsPermissionsId",
                table: "Roles",
                column: "TestimonialsPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_AuthorId",
                table: "Testimonials",
                column: "AuthorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_ContentId",
                table: "Testimonials",
                column: "ContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_ImageId",
                table: "Testimonials",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_JobId",
                table: "Testimonials",
                column: "JobId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_TestimonialsPermissionsId",
                table: "Roles",
                column: "TestimonialsPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_TestimonialsPermissionsId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Roles_TestimonialsPermissionsId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TestimonialsPermissionsId",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 16, 10, 38, 540, DateTimeKind.Local).AddTicks(6747), new DateTime(2022, 6, 30, 16, 10, 38, 541, DateTimeKind.Local).AddTicks(7210), new byte[] { 79, 57, 49, 217, 221, 35, 13, 31, 171, 208, 171, 157, 73, 35, 63, 229, 189, 149, 90, 52, 227, 223, 135, 58, 20, 144, 11, 89, 123, 173, 207, 113, 54, 107, 74, 12, 118, 112, 170, 255, 75, 234, 212, 216, 33, 97, 0, 211, 58, 14, 119, 118, 217, 128, 50, 37, 111, 201, 149, 110, 43, 168, 132, 208 }, new byte[] { 201, 48, 26, 209, 91, 95, 107, 137, 152, 198, 3, 114, 146, 230, 98, 45, 249, 87, 203, 250, 239, 141, 142, 122, 250, 248, 85, 202, 183, 170, 132, 234, 103, 106, 187, 8, 34, 176, 217, 40, 200, 212, 207, 10, 135, 61, 125, 116, 69, 147, 157, 138, 65, 226, 58, 20, 11, 164, 219, 140, 75, 43, 119, 30, 51, 211, 75, 75, 122, 46, 110, 203, 133, 77, 4, 18, 181, 112, 67, 79, 149, 130, 139, 72, 186, 45, 187, 252, 181, 244, 138, 244, 87, 163, 234, 116, 75, 254, 161, 118, 214, 193, 143, 165, 36, 179, 105, 66, 105, 224, 193, 58, 181, 251, 134, 241, 152, 36, 86, 105, 117, 220, 36, 124, 122, 19, 158, 141 } });
        }
    }
}
