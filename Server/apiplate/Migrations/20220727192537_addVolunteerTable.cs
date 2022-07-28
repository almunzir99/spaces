using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addVolunteerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CVLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volunteers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_volunteers_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 27, 21, 25, 36, 14, DateTimeKind.Local).AddTicks(8159), new DateTime(2022, 7, 27, 21, 25, 36, 15, DateTimeKind.Local).AddTicks(7890), new byte[] { 49, 80, 80, 206, 252, 34, 97, 122, 117, 90, 51, 80, 180, 52, 138, 143, 219, 39, 215, 140, 211, 131, 252, 212, 42, 96, 176, 90, 135, 157, 31, 155, 0, 172, 251, 139, 158, 169, 221, 52, 249, 221, 120, 230, 97, 219, 192, 37, 98, 177, 147, 102, 242, 74, 101, 33, 205, 133, 169, 144, 127, 80, 0, 211 }, new byte[] { 29, 47, 11, 18, 110, 55, 81, 74, 192, 99, 233, 245, 100, 231, 47, 15, 14, 101, 73, 236, 187, 161, 95, 35, 151, 159, 158, 22, 96, 171, 108, 5, 157, 159, 113, 194, 8, 197, 75, 224, 189, 119, 28, 29, 118, 178, 95, 82, 116, 132, 252, 106, 114, 171, 6, 171, 247, 241, 249, 140, 215, 9, 92, 177, 47, 210, 121, 102, 60, 19, 60, 161, 160, 40, 119, 163, 107, 97, 184, 171, 75, 2, 255, 162, 76, 41, 142, 79, 201, 170, 233, 91, 94, 171, 223, 101, 24, 163, 237, 39, 192, 147, 252, 205, 82, 114, 194, 38, 184, 121, 55, 17, 129, 126, 91, 25, 177, 254, 145, 40, 190, 36, 99, 95, 190, 52, 172, 201 } });

            migrationBuilder.CreateIndex(
                name: "IX_volunteers_SectorId",
                table: "volunteers",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "volunteers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 9, 1, 25, 41, 848, DateTimeKind.Local).AddTicks(4374), new DateTime(2022, 7, 9, 1, 25, 41, 849, DateTimeKind.Local).AddTicks(4784), new byte[] { 68, 24, 214, 165, 192, 113, 128, 86, 24, 162, 224, 189, 176, 54, 47, 212, 243, 97, 164, 148, 94, 140, 47, 16, 51, 166, 57, 164, 250, 253, 135, 99, 162, 235, 133, 63, 187, 191, 116, 3, 76, 96, 167, 115, 80, 130, 198, 36, 22, 116, 33, 238, 68, 26, 191, 60, 237, 43, 198, 9, 9, 161, 83, 65 }, new byte[] { 133, 252, 35, 208, 226, 180, 194, 199, 242, 203, 251, 236, 244, 22, 11, 49, 48, 230, 79, 121, 44, 50, 106, 176, 200, 105, 146, 106, 229, 67, 178, 80, 218, 184, 174, 41, 218, 101, 131, 250, 158, 112, 149, 157, 92, 54, 92, 197, 41, 176, 212, 10, 0, 219, 237, 179, 73, 186, 143, 27, 247, 155, 53, 139, 250, 137, 191, 19, 43, 23, 175, 87, 141, 103, 54, 74, 214, 243, 10, 253, 47, 73, 234, 140, 231, 30, 101, 17, 232, 36, 27, 71, 118, 85, 77, 229, 217, 35, 236, 134, 199, 236, 81, 232, 228, 249, 234, 37, 245, 137, 86, 205, 94, 219, 145, 211, 208, 76, 56, 152, 123, 125, 100, 94, 219, 148, 217, 192 } });
        }
    }
}
