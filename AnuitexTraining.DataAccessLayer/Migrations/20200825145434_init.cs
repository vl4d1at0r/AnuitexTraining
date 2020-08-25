using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    TransactionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrintingEditions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintingEditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PaymentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorInPrintingEditions",
                columns: table => new
                {
                    AuthorId = table.Column<long>(nullable: false),
                    PrintingEditionId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorInPrintingEditions", x => new { x.AuthorId, x.PrintingEditionId });
                    table.ForeignKey(
                        name: "FK_AuthorInPrintingEditions_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId",
                        column: x => x.PrintingEditionId,
                        principalTable: "PrintingEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    PrintingEditionId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    Count = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_PrintingEditions_PrintingEditionId",
                        column: x => x.PrintingEditionId,
                        principalTable: "PrintingEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "82d9e75d-8bb7-4a34-a5bc-a63d76910d5f", "Admin", null },
                    { 2L, "64d7a927-3f33-4746-8bbc-86d3d315a4c1", "Client", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, "ecd479e9-9177-45da-a79d-eedce77e207d", new DateTime(2020, 8, 25, 14, 54, 23, 702, DateTimeKind.Utc).AddTicks(9051), "vladiator@xitroo.com", true, "Vladislav", "Goncharuk", false, null, "VLADIATOR@XITROO.COM", "VLADIATOR", "AQAAAAEAACcQAAAAEKHk3sTABbsMTgCaH81KcsHXbNSfveaBeQYBbLM8tOS5EKut5YWZcDbh7uCXUARPmQ==", null, false, "UD6OIMX72OWACSZNP6QXRDB6AK5UAQWK", false, "vladiator" },
                    { 2L, 0, "1131d3d0-5cd8-477a-b859-391a1951093a", new DateTime(2020, 8, 25, 14, 54, 23, 702, DateTimeKind.Utc).AddTicks(9104), "valera@xitroo.com", true, "Valerij", "Jmishenko", false, null, "VALERA@XITROO.COM", "VALERAJMIH", "AQAAAAEAACcQAAAAELXM6ETOnIrNLqiksYqOZZ1tKbsO/TLM1hKXn9FCvapFZEcWYLcYxvK9rxxxDSQCSA==", null, false, "P5IWCILRLNALOGOW77G2WLTUREFC7BZG", false, "valerajmih" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 25, 14, 54, 23, 701, DateTimeKind.Utc).AddTicks(8300), false, "Jmih V.A." },
                    { 2L, new DateTime(2020, 8, 25, 14, 54, 23, 701, DateTimeKind.Utc).AddTicks(8797), false, "Drozdov G.L." },
                    { 3L, new DateTime(2020, 8, 25, 14, 54, 23, 701, DateTimeKind.Utc).AddTicks(8806), false, "Teodorov V.V." },
                    { 4L, new DateTime(2020, 8, 25, 14, 54, 23, 701, DateTimeKind.Utc).AddTicks(8808), false, "Kovalenko S.A." },
                    { 5L, new DateTime(2020, 8, 25, 14, 54, 23, 701, DateTimeKind.Utc).AddTicks(8810), false, "Gorin O.V." }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "TransactionId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 25, 14, 54, 23, 702, DateTimeKind.Utc).AddTicks(2649), false, 21847238958L },
                    { 2L, new DateTime(2020, 8, 25, 14, 54, 23, 702, DateTimeKind.Utc).AddTicks(3047), false, 57976548678L }
                });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "CreationDate", "Currency", "Description", "IsRemoved", "Price", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 25, 14, 54, 23, 701, DateTimeKind.Utc).AddTicks(9222), 6, "Neurotechnologies", false, 1000.0, null, 0 },
                    { 2L, new DateTime(2020, 8, 25, 14, 54, 23, 702, DateTimeKind.Utc).AddTicks(518), 2, "C# Starter", false, 20.0, null, 0 },
                    { 3L, new DateTime(2020, 8, 25, 14, 54, 23, 702, DateTimeKind.Utc).AddTicks(548), 1, "ASP.NET MVC 5", false, 100.0, null, 0 },
                    { 4L, new DateTime(2020, 8, 25, 14, 54, 23, 702, DateTimeKind.Utc).AddTicks(550), 2, "How it works", false, 50.0, null, 0 },
                    { 5L, new DateTime(2020, 8, 25, 14, 54, 23, 702, DateTimeKind.Utc).AddTicks(552), 1, "Angular 9", false, 70.0, null, 0 }
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
                    { 1L, new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(2395), new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(2399), "Nothing special", false, 1L, 1, 2L },
                    { 2L, new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(4046), new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(4047), "And here is nothing special", false, 2L, 2, 2L }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Amount", "Count", "CreationDate", "Currency", "IsRemoved", "OrderId", "PrintingEditionId" },
                values: new object[,]
                {
                    { 1L, 2, 2000.0, new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(4525), 6, false, 1L, 1L },
                    { 3L, 4, 80.0, new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(7385), 2, false, 1L, 2L },
                    { 4L, 10, 500.0, new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(7388), 2, false, 1L, 4L },
                    { 5L, 6, 420.0, new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(7390), 1, false, 1L, 5L },
                    { 2L, 7, 7000.0, new DateTime(2020, 8, 25, 14, 54, 23, 703, DateTimeKind.Utc).AddTicks(7266), 6, false, 2L, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions",
                column: "PrintingEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PrintingEditionId",
                table: "OrderItems",
                column: "PrintingEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuthorInPrintingEditions");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PrintingEditions");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
