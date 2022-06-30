using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class addPriorityToTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 12, 44, 646, DateTimeKind.Local).AddTicks(1659), new DateTime(2022, 6, 30, 11, 12, 44, 648, DateTimeKind.Local).AddTicks(25), new byte[] { 49, 141, 17, 220, 160, 10, 188, 254, 134, 65, 100, 199, 47, 1, 204, 91, 18, 243, 213, 172, 78, 28, 106, 238, 49, 96, 182, 253, 161, 149, 157, 97, 135, 96, 236, 28, 177, 150, 84, 10, 66, 21, 187, 200, 169, 184, 176, 237, 38, 14, 48, 27, 64, 251, 154, 229, 186, 101, 60, 93, 4, 66, 231, 226 }, new byte[] { 160, 138, 210, 75, 196, 143, 206, 178, 38, 147, 123, 47, 168, 148, 58, 210, 203, 41, 14, 234, 15, 88, 94, 247, 189, 85, 213, 29, 70, 99, 2, 218, 97, 193, 121, 18, 206, 46, 88, 240, 242, 56, 94, 110, 150, 68, 109, 29, 149, 232, 218, 249, 82, 87, 128, 106, 70, 71, 21, 254, 241, 193, 44, 187, 73, 111, 9, 121, 62, 53, 180, 168, 56, 9, 16, 48, 201, 65, 167, 98, 231, 46, 68, 173, 252, 171, 135, 252, 1, 8, 44, 110, 229, 150, 207, 43, 113, 40, 102, 121, 33, 7, 125, 199, 183, 145, 70, 189, 162, 224, 0, 244, 114, 154, 44, 225, 62, 213, 67, 154, 146, 240, 126, 143, 194, 148, 152, 165 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Team");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 3, 16, 4, DateTimeKind.Local).AddTicks(3232), new DateTime(2022, 6, 30, 11, 3, 16, 5, DateTimeKind.Local).AddTicks(3496), new byte[] { 237, 77, 137, 184, 56, 186, 1, 21, 96, 73, 254, 102, 42, 201, 59, 17, 4, 93, 242, 104, 43, 166, 254, 78, 74, 190, 190, 189, 73, 21, 164, 37, 132, 117, 134, 59, 219, 120, 4, 196, 221, 197, 55, 37, 112, 243, 217, 53, 240, 191, 86, 19, 56, 224, 251, 27, 247, 48, 226, 130, 242, 75, 138, 31 }, new byte[] { 202, 254, 158, 68, 37, 199, 158, 190, 61, 155, 86, 43, 213, 146, 50, 107, 213, 225, 11, 200, 3, 219, 206, 146, 157, 167, 15, 4, 78, 134, 225, 201, 156, 244, 69, 12, 107, 162, 255, 54, 226, 247, 1, 255, 152, 91, 5, 21, 100, 33, 227, 60, 252, 198, 131, 64, 54, 228, 102, 85, 15, 176, 149, 73, 103, 97, 198, 201, 201, 77, 149, 250, 170, 42, 63, 101, 181, 54, 0, 151, 159, 161, 230, 218, 177, 73, 50, 67, 217, 162, 8, 233, 49, 16, 90, 96, 52, 110, 75, 186, 135, 40, 179, 92, 115, 131, 25, 122, 253, 60, 230, 125, 22, 19, 26, 49, 52, 222, 53, 110, 245, 148, 180, 214, 188, 252, 217, 216 } });
        }
    }
}
