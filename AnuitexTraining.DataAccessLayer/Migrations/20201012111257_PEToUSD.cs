using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class PEToUSD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "cefeaf1b-675d-4827-8b50-ac7bb8da33bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "0db56b40-8be4-431b-8b68-2423d22f538d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "2247fe65-c3f2-4b90-a403-0a58b21e05a3", new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "7848ac0a-b54c-4f15-99a2-76e9a12dd196", new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(1240), 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(2600), 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(2672), 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(2675), 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(123), new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(126) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(996), new DateTime(2020, 10, 12, 11, 12, 53, 769, DateTimeKind.Utc).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(1722), 1 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(2812), 1 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(2854), 1 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 12, 11, 12, 53, 768, DateTimeKind.Utc).AddTicks(2857));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "5aa242a2-cf6a-43ff-b98c-faa652b7eb50");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "98d5b7a5-fcc1-4f0f-a177-3a981b5fa4fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "f2c98468-b6cf-4cde-81e4-ace0be43b661", new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(7868) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "78311e35-9d2c-4937-8228-20dd89fe32b8", new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(8097) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(1310), 6 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(2644), 6 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(2711), 2 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(2714), 2 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(217), new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(1071), new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(4135));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(1912), 6 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(3005), 2 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreationDate", "Currency" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(3044), 2 });

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(3046));
        }
    }
}
