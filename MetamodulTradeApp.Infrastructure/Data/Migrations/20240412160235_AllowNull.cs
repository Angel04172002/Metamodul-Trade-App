using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetamodulTradeApp.Infrastructure.Migrations
{
    public partial class AllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 12, 19, 2, 34, 557, DateTimeKind.Local).AddTicks(9767));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
