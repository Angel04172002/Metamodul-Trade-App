using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetamodulTradeApp.Infrastructure.Migrations
{
    public partial class ChangedCommentCreatorIdToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
