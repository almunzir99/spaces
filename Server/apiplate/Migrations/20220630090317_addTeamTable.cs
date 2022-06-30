using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Translations_NameId",
                        column: x => x.NameId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Translations_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 3, 16, 4, DateTimeKind.Local).AddTicks(3232), new DateTime(2022, 6, 30, 11, 3, 16, 5, DateTimeKind.Local).AddTicks(3496), new byte[] { 237, 77, 137, 184, 56, 186, 1, 21, 96, 73, 254, 102, 42, 201, 59, 17, 4, 93, 242, 104, 43, 166, 254, 78, 74, 190, 190, 189, 73, 21, 164, 37, 132, 117, 134, 59, 219, 120, 4, 196, 221, 197, 55, 37, 112, 243, 217, 53, 240, 191, 86, 19, 56, 224, 251, 27, 247, 48, 226, 130, 242, 75, 138, 31 }, new byte[] { 202, 254, 158, 68, 37, 199, 158, 190, 61, 155, 86, 43, 213, 146, 50, 107, 213, 225, 11, 200, 3, 219, 206, 146, 157, 167, 15, 4, 78, 134, 225, 201, 156, 244, 69, 12, 107, 162, 255, 54, 226, 247, 1, 255, 152, 91, 5, 21, 100, 33, 227, 60, 252, 198, 131, 64, 54, 228, 102, 85, 15, 176, 149, 73, 103, 97, 198, 201, 201, 77, 149, 250, 170, 42, 63, 101, 181, 54, 0, 151, 159, 161, 230, 218, 177, 73, 50, 67, 217, 162, 8, 233, 49, 16, 90, 96, 52, 110, 75, 186, 135, 40, 179, 92, 115, 131, 25, 122, 253, 60, 230, 125, 22, 19, 26, 49, 52, 222, 53, 110, 245, 148, 180, 214, 188, 252, 217, 216 } });

            migrationBuilder.CreateIndex(
                name: "IX_Team_ImageId",
                table: "Team",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_NameId",
                table: "Team",
                column: "NameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_PositionId",
                table: "Team",
                column: "PositionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 20, 21, 268, DateTimeKind.Local).AddTicks(747), new DateTime(2022, 6, 30, 10, 20, 21, 269, DateTimeKind.Local).AddTicks(8323), new byte[] { 91, 157, 6, 156, 107, 190, 168, 58, 94, 59, 156, 44, 94, 181, 173, 64, 223, 172, 94, 80, 158, 35, 97, 1, 29, 38, 157, 71, 213, 236, 26, 137, 62, 158, 56, 143, 165, 227, 187, 9, 49, 137, 125, 52, 222, 116, 228, 88, 227, 212, 57, 254, 219, 226, 162, 254, 155, 209, 196, 95, 238, 25, 74, 181 }, new byte[] { 220, 143, 225, 13, 188, 169, 208, 157, 86, 86, 143, 231, 155, 198, 196, 227, 180, 9, 241, 191, 124, 101, 233, 67, 24, 64, 4, 97, 72, 49, 148, 48, 120, 145, 157, 209, 54, 114, 118, 184, 39, 169, 27, 77, 162, 25, 106, 50, 218, 159, 199, 46, 220, 42, 178, 238, 255, 32, 192, 174, 117, 97, 28, 10, 87, 36, 93, 105, 199, 78, 183, 43, 218, 105, 121, 187, 195, 166, 10, 92, 38, 202, 51, 244, 211, 222, 111, 56, 0, 175, 42, 137, 144, 87, 86, 95, 220, 179, 18, 102, 29, 192, 120, 17, 66, 9, 85, 237, 177, 28, 84, 228, 17, 77, 27, 58, 199, 144, 254, 106, 83, 198, 214, 221, 29, 112, 116, 52 } });
        }
    }
}
