using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class petypefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "0ba94bcb-44e1-4e67-818c-7c39902f2b4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "ce4ce46e-e990-4557-8774-851480adca9d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "dd073ae5-f287-4c44-937f-690211d26d4e", new DateTime(2020, 8, 31, 14, 4, 57, 60, DateTimeKind.Utc).AddTicks(2561) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "268af5ac-5dd4-4a97-87d3-ac58327c4583", new DateTime(2020, 8, 31, 14, 4, 57, 60, DateTimeKind.Utc).AddTicks(2628) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(968));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(971));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 60, DateTimeKind.Utc).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 61, DateTimeKind.Utc).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 61, DateTimeKind.Utc).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 61, DateTimeKind.Utc).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 61, DateTimeKind.Utc).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 4, 57, 60, DateTimeKind.Utc).AddTicks(5971), new DateTime(2020, 8, 31, 14, 4, 57, 60, DateTimeKind.Utc).AddTicks(5975) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 4, 57, 60, DateTimeKind.Utc).AddTicks(7750), new DateTime(2020, 8, 31, 14, 4, 57, 60, DateTimeKind.Utc).AddTicks(7751) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(1382), 3 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(3508), 1 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(3561), 1 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(3563), 2 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 4, 57, 59, DateTimeKind.Utc).AddTicks(3573), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "e8a198f1-7a35-421b-9a61-896df2fad7f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "ea737a0f-0054-4e4c-9d11-9eaaf31512ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "505e2afa-6bbc-4e46-91c6-17ec525afb00", new DateTime(2020, 8, 31, 7, 16, 18, 640, DateTimeKind.Utc).AddTicks(6167) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "442a3148-4a82-44ec-bea6-f1f6c76a9225", new DateTime(2020, 8, 31, 7, 16, 18, 640, DateTimeKind.Utc).AddTicks(6229) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 641, DateTimeKind.Utc).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 641, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 641, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 641, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 641, DateTimeKind.Utc).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 31, 7, 16, 18, 640, DateTimeKind.Utc).AddTicks(9416), new DateTime(2020, 8, 31, 7, 16, 18, 640, DateTimeKind.Utc).AddTicks(9420) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 31, 7, 16, 18, 641, DateTimeKind.Utc).AddTicks(1328), new DateTime(2020, 8, 31, 7, 16, 18, 641, DateTimeKind.Utc).AddTicks(1329) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(5457), 0 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(7075), 0 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(7107), 0 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(7109), 0 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreationDate", "Type" },
                values: new object[] { new DateTime(2020, 8, 31, 7, 16, 18, 639, DateTimeKind.Utc).AddTicks(7111), 0 });
        }
    }
}
