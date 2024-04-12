using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetamodulTradeApp.Infrastructure.Migrations
{
    public partial class ChangedCreatorIdOfClientRequestToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 12, 18, 55, 55, 426, DateTimeKind.Local).AddTicks(7163));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 10, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9408));
        }
    }
}
