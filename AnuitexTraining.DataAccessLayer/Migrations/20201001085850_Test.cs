using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 989, DateTimeKind.Utc).AddTicks(2714));

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
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(3005));

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
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(3044));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 58, 49, 988, DateTimeKind.Utc).AddTicks(3046));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "0fa155c9-f399-43e6-a9e9-0c5430ce9423");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "c7f02521-c947-421c-9f78-1b3a6f7959f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "79fa4f31-da15-4036-acce-e86b9c1a4684", new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(3757) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "823744ab-a60b-4eb5-b314-ca1992d4afe1", new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(4025) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(5832), new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(6733), new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(6734) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(6572));
        }
    }
}
