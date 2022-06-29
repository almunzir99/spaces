using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiplate.Migrations
{
    public partial class createNotificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Users_AdminId",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_AdminId",
                table: "Notifications",
                newName: "IX_Notifications_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 6, 7, 23, 1, 29, 171, DateTimeKind.Local).AddTicks(2305), new DateTime(2022, 6, 7, 23, 1, 29, 172, DateTimeKind.Local).AddTicks(2586), new byte[] { 155, 237, 118, 70, 202, 176, 246, 102, 103, 193, 107, 250, 59, 105, 158, 28, 47, 47, 145, 162, 212, 36, 84, 142, 6, 70, 113, 217, 164, 15, 244, 92, 29, 103, 76, 77, 179, 196, 190, 174, 63, 92, 111, 155, 18, 130, 156, 209, 92, 1, 42, 183, 115, 146, 202, 195, 53, 24, 239, 217, 159, 61, 236, 90 }, new byte[] { 127, 26, 190, 83, 82, 216, 45, 188, 199, 132, 160, 82, 205, 222, 64, 220, 34, 116, 249, 159, 64, 118, 147, 95, 33, 62, 36, 53, 83, 117, 159, 69, 132, 142, 82, 63, 160, 176, 189, 7, 246, 196, 90, 67, 158, 63, 78, 109, 253, 5, 98, 249, 213, 187, 117, 162, 9, 65, 238, 24, 196, 193, 107, 133, 30, 7, 126, 254, 134, 1, 23, 28, 41, 166, 98, 63, 94, 58, 242, 107, 183, 16, 219, 92, 4, 171, 103, 51, 0, 172, 141, 225, 122, 79, 226, 49, 73, 120, 172, 30, 246, 104, 52, 227, 36, 89, 164, 166, 178, 45, 137, 153, 197, 212, 30, 130, 35, 103, 118, 17, 67, 112, 37, 97, 112, 70, 101, 151 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_AdminId",
                table: "Notifications",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_AdminId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_AdminId",
                table: "Notification",
                newName: "IX_Notification_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 1, 6, 19, 15, 31, 405, DateTimeKind.Local).AddTicks(1782), new DateTime(2022, 1, 6, 19, 15, 31, 406, DateTimeKind.Local).AddTicks(2605), new byte[] { 73, 218, 218, 62, 7, 45, 61, 253, 255, 224, 21, 6, 232, 76, 64, 68, 4, 70, 252, 240, 190, 73, 17, 228, 212, 29, 195, 142, 57, 218, 190, 94, 141, 137, 27, 97, 177, 224, 183, 127, 254, 75, 73, 4, 6, 195, 132, 87, 99, 29, 72, 30, 160, 213, 254, 205, 105, 69, 104, 177, 121, 79, 156, 251 }, new byte[] { 175, 160, 68, 94, 79, 216, 65, 90, 84, 32, 200, 82, 48, 188, 189, 76, 247, 159, 152, 16, 113, 132, 2, 101, 69, 231, 102, 15, 28, 182, 46, 72, 51, 199, 196, 18, 211, 54, 57, 115, 67, 29, 144, 33, 187, 162, 109, 65, 55, 71, 206, 129, 142, 188, 45, 99, 172, 169, 113, 96, 50, 0, 64, 203, 107, 38, 33, 252, 244, 64, 237, 173, 146, 242, 87, 101, 163, 238, 39, 166, 34, 95, 56, 229, 214, 95, 43, 233, 198, 47, 78, 134, 242, 4, 172, 129, 40, 123, 132, 77, 237, 137, 243, 174, 114, 77, 162, 168, 149, 115, 26, 3, 149, 11, 79, 130, 174, 75, 144, 229, 2, 140, 105, 6, 163, 254, 237, 109 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Users_AdminId",
                table: "Notification",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
