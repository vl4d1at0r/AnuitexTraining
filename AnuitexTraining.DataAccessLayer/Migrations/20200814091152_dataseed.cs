using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "dab3248a-d084-46cb-8a17-d5bcdcb80746", "Admin", null },
                    { 2L, "5ec8f356-fc36-4eff-898e-2cb3d173a306", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, "dc0d8920-1d35-46be-8fc6-174da8c3470a", "admin@example.com", true, "Vladislav", "Goncharuk", false, null, null, null, null, "+380935538212", true, null, false, "vladiator" },
                    { 2L, 0, "34302700-6e80-4a40-88bd-fe655a9d6f31", "user@example.com", true, "Valerij", "Jmishenko", false, null, null, null, null, "+380503487621", true, null, false, "valerajmih" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 14, 12, 11, 51, 925, DateTimeKind.Local).AddTicks(7109), false, "Jmih V.A." },
                    { 2L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(2632), false, "Drozdov G.L." },
                    { 3L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(2682), false, "Teodorov V.V." },
                    { 4L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(2687), false, "Kovalenko S.A." },
                    { 5L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(2690), false, "Gorin O.V." }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "TransactionId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(6746), false, 21847238958L },
                    { 2L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(7215), false, 57976548678L }
                });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "CreationDate", "Currency", "Description", "IsRemoved", "Price", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(3180), 6, "Neurotechnologies", false, 1000.0, null, 0 },
                    { 2L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(4527), 2, "C# Starter", false, 20.0, null, 0 },
                    { 3L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(4619), 1, "ASP.NET MVC 5", false, 100.0, null, 0 },
                    { 4L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(4624), 2, "How it works", false, 50.0, null, 0 },
                    { 5L, new DateTime(2020, 8, 14, 12, 11, 51, 928, DateTimeKind.Local).AddTicks(4627), 1, "Angular 9", false, 70.0, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L }
                });

            migrationBuilder.InsertData(
                table: "AuthorInPrintingEditions",
                columns: new[] { "AuthorId", "PrintingEditionId", "Date" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2008, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2010, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, new DateTime(2016, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 4L, new DateTime(2002, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 5L, new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreationDate", "Date", "Description", "IsRemoved", "PaymentId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(5337), new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(5354), "Nothing special", false, 1L, 1, 2L },
                    { 2L, new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(7002), new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(7016), "And here is nothing special", false, 2L, 2, 2L }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Amount", "Count", "CreationDate", "Currency", "IsRemoved", "OrderId", "PrintingEditionId" },
                values: new object[,]
                {
                    { 1L, 2, 2000.0, new DateTime(2020, 8, 14, 12, 11, 51, 929, DateTimeKind.Local).AddTicks(7456), 6, false, 1L, 1L },
                    { 3L, 4, 80.0, new DateTime(2020, 8, 14, 12, 11, 51, 930, DateTimeKind.Local).AddTicks(487), 2, false, 1L, 2L },
                    { 4L, 10, 500.0, new DateTime(2020, 8, 14, 12, 11, 51, 930, DateTimeKind.Local).AddTicks(492), 2, false, 1L, 4L },
                    { 5L, 6, 420.0, new DateTime(2020, 8, 14, 12, 11, 51, 930, DateTimeKind.Local).AddTicks(495), 1, false, 1L, 5L },
                    { 2L, 7, 7000.0, new DateTime(2020, 8, 14, 12, 11, 51, 930, DateTimeKind.Local).AddTicks(425), 6, false, 2L, 1L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 4L, 4L });

            migrationBuilder.DeleteData(
                table: "AuthorInPrintingEditions",
                keyColumns: new[] { "AuthorId", "PrintingEditionId" },
                keyValues: new object[] { 5L, 5L });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
