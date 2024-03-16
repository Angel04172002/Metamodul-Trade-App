using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetamodulTradeApp.Infrastructure.Migrations
{
    public partial class NewFieldAddedAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ClientRequests",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Client's phone number");

            migrationBuilder.InsertData(
                table: "ClientRequests",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "Message", "PhoneNumber", "Topic" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(8065), "506cd08d-e8d0-4d5c-9796-949558867648", "Съобщение от Петър", "0882426666", "Заявка от Петър" },
                    { 2, new DateTime(2023, 10, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(8099), "506cd08d-e8d0-4d5c-9796-949558867648", "Съобщение 2 от Петър", "0882426666", "Заявка 2 от Петър" },
                    { 3, new DateTime(2024, 1, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(8103), "ece06352-f235-4345-94a7-1a2c12f03ac6", "Съобщение от Ангел", "0888556753", "Заявка от Ангел" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9144), "ece06352-f235-4345-94a7-1a2c12f03ac6", "Описание на пост 1 за камиони", "https://i.stack.imgur.com/GsDIl.jpg", "Пост за камиони" },
                    { 2, new DateTime(2023, 11, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9159), "ece06352-f235-4345-94a7-1a2c12f03ac6", "Описание на пост 2 за природен газ", "https://i.stack.imgur.com/GsDIl.jpg", "Пост за природен газ" },
                    { 3, new DateTime(2024, 2, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9162), "ece06352-f235-4345-94a7-1a2c12f03ac6", "Описание на пост 3 за масла", "https://i.stack.imgur.com/GsDIl.jpg", "Пост за масла" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Камиони" },
                    { 2, "Масла" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedOn", "CreatorId", "PostId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9262), "ece06352-f235-4345-94a7-1a2c12f03ac6", 1, "Откъде мога да си купя този продукт?" },
                    { 2, new DateTime(2023, 10, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9268), "ece06352-f235-4345-94a7-1a2c12f03ac6", 1, "Оставям ви имейл за връзка" },
                    { 3, new DateTime(2023, 12, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9271), "506cd08d-e8d0-4d5c-9796-949558867648", 3, "Много хубава статия!" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "CreatorId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 12, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9403), "ece06352-f235-4345-94a7-1a2c12f03ac6", "Моторно масло за двигател", "https://www.stitchandskein.com/media/2021/08/wheel-oil.jpg", "Масло", 70m },
                    { 2, 1, new DateTime(2023, 12, 17, 1, 8, 43, 386, DateTimeKind.Local).AddTicks(9408), "ece06352-f235-4345-94a7-1a2c12f03ac6", "Камион за превоз на машини", "https://www.stitchandskein.com/media/2021/08/wheel-oil.jpg", "Камион", 15000m }
                });

            migrationBuilder.InsertData(
                table: "UsersProducts",
                columns: new[] { "ProductId", "UserId" },
                values: new object[] { 1, "506cd08d-e8d0-4d5c-9796-949558867648" });

            migrationBuilder.InsertData(
                table: "UsersProducts",
                columns: new[] { "ProductId", "UserId" },
                values: new object[] { 2, "506cd08d-e8d0-4d5c-9796-949558867648" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UsersProducts",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { 1, "506cd08d-e8d0-4d5c-9796-949558867648" });

            migrationBuilder.DeleteData(
                table: "UsersProducts",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { 2, "506cd08d-e8d0-4d5c-9796-949558867648" });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ClientRequests");
        }
    }
}
