using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetamodulTradeApp.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8=83d9-d6b3ac1f591e", 0, "95a0e957-3166-41dc-bd45-1b5d46cf3e7a", "angel04172002@gmail.com", false, false, null, "ANGEL04172002@GMAIL.COM", "ANGEL04172002@GMAIL.COM", "AQAAAAEAACcQAAAAEGrDe351zDWTjnDWG9oTSaife7ZaDPfK5qyZFIZxr/LtoTSHB6BJbDM+fuzIu3UQow==", null, false, "36ee9bba-7db8-4ea5-9165-98d4c453bb39", false, "angel04172002@gmail.com" });

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 21, 55, 46, 215, DateTimeKind.Local).AddTicks(8976));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8=83d9-d6b3ac1f591e");

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 17, 43, 21, 706, DateTimeKind.Local).AddTicks(3998));
        }
    }
}
