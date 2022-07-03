using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addSubjectColumnToMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 7, 3, 17, 33, 38, 559, DateTimeKind.Local).AddTicks(6920), new DateTime(2022, 7, 3, 17, 33, 38, 560, DateTimeKind.Local).AddTicks(7491), new byte[] { 57, 174, 130, 157, 123, 107, 98, 27, 171, 152, 71, 108, 116, 99, 198, 16, 40, 106, 87, 204, 66, 241, 68, 138, 70, 15, 178, 129, 164, 218, 59, 92, 142, 96, 171, 229, 140, 167, 138, 133, 247, 218, 57, 171, 135, 196, 195, 92, 73, 87, 2, 222, 183, 98, 85, 20, 64, 127, 9, 242, 63, 252, 83, 146 }, new byte[] { 14, 33, 235, 158, 86, 182, 220, 142, 245, 202, 153, 167, 81, 243, 89, 160, 145, 241, 128, 39, 15, 50, 181, 82, 187, 228, 139, 160, 114, 52, 146, 107, 77, 188, 5, 70, 77, 152, 36, 58, 45, 230, 73, 241, 128, 92, 192, 129, 9, 141, 35, 91, 6, 239, 243, 107, 213, 164, 31, 171, 159, 22, 229, 8, 156, 213, 228, 58, 195, 130, 182, 61, 45, 208, 58, 176, 195, 77, 66, 218, 64, 87, 212, 103, 62, 93, 210, 141, 120, 255, 206, 213, 2, 177, 59, 45, 246, 198, 31, 198, 52, 235, 32, 45, 25, 121, 118, 193, 191, 106, 111, 139, 100, 215, 219, 203, 86, 191, 210, 255, 238, 149, 244, 180, 248, 215, 231, 44 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 22, 53, 40, 156, DateTimeKind.Local).AddTicks(7370), new DateTime(2022, 6, 30, 22, 53, 40, 157, DateTimeKind.Local).AddTicks(7715), new byte[] { 155, 251, 239, 206, 199, 191, 239, 83, 80, 103, 135, 199, 200, 96, 190, 254, 47, 212, 2, 55, 169, 5, 238, 248, 65, 245, 29, 11, 92, 48, 229, 152, 27, 15, 170, 103, 131, 222, 145, 197, 43, 103, 36, 233, 85, 92, 182, 47, 49, 87, 244, 219, 107, 143, 102, 102, 187, 255, 62, 62, 47, 127, 21, 214 }, new byte[] { 52, 161, 135, 203, 17, 27, 25, 239, 230, 51, 193, 25, 179, 166, 167, 11, 99, 140, 38, 135, 200, 57, 150, 35, 71, 51, 142, 179, 80, 213, 76, 80, 82, 81, 184, 40, 212, 183, 77, 182, 26, 201, 10, 118, 130, 11, 3, 51, 139, 128, 238, 58, 171, 98, 169, 99, 124, 179, 234, 124, 202, 159, 134, 51, 12, 219, 157, 70, 253, 121, 195, 126, 207, 242, 162, 162, 226, 2, 227, 105, 2, 252, 127, 90, 99, 208, 65, 106, 32, 9, 151, 239, 7, 88, 82, 187, 213, 215, 230, 128, 251, 211, 118, 197, 0, 49, 172, 22, 167, 229, 30, 235, 245, 165, 121, 180, 248, 88, 72, 198, 55, 93, 94, 162, 206, 76, 211, 26 } });
        }
    }
}
