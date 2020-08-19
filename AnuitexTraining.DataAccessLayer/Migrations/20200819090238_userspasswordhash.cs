using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class userspasswordhash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "79e9df8c-0013-45a2-8617-55d25c2f5866");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "12ef384d-203c-49c6-9857-9d000e171721");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d16cf3b-eef8-4e1a-9c02-9463c9d13939", "937e8d5fbb48bd4949536cd65b8d35c426b80d2f830c5c308e2cdec422ae2244" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5774fe3-e32c-49f5-b312-c8d093004436", "937e8d5fbb48bd4949536cd65b8d35c426b80d2f830c5c308e2cdec422ae2244" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 746, DateTimeKind.Local).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 748, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 748, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 748, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 748, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(2638), new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(2655) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(4330), new DateTime(2020, 8, 19, 12, 2, 37, 750, DateTimeKind.Local).AddTicks(4343) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 749, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 749, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 749, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 749, DateTimeKind.Local).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 749, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 749, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 19, 12, 2, 37, 749, DateTimeKind.Local).AddTicks(1756));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "dab3248a-d084-46cb-8a17-d5bcdcb80746");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "5ec8f356-fc36-4eff-898e-2cb3d173a306");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc0d8920-1d35-46be-8fc6-174da8c3470a", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "34302700-6e80-4a40-88bd-fe655a9d6f31", null });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 925, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 930, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 930, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 930, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 930, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(5337), new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "Date" },
                values: new object[] { new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(7002), new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(7016) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(4627));
        }
    }
}
