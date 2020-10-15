using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class Init : Migration
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
                    IsBlocked = table.Column<bool>(nullable: false),
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
                    TransactionId = table.Column<string>(nullable: true)
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
                    Amount = table.Column<double>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    PrintingEditionId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false)
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
                    { 1L, "0fa155c9-f399-43e6-a9e9-0c5430ce9423", "Admin", "ADMIN" },
                    { 2L, "c7f02521-c947-421c-9f78-1b3a6f7959f0", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "IsBlocked", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, "79fa4f31-da15-4036-acce-e86b9c1a4684", new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(3757), "vladiator@xitroo.com", true, "Vladislav", false, "Goncharuk", false, null, "VLADIATOR@XITROO.COM", "VLADIATOR", "AQAAAAEAACcQAAAAEKHk3sTABbsMTgCaH81KcsHXbNSfveaBeQYBbLM8tOS5EKut5YWZcDbh7uCXUARPmQ==", "", false, "UD6OIMX72OWACSZNP6QXRDB6AK5UAQWK", false, "vladiator" },
                    { 2L, 0, "823744ab-a60b-4eb5-b314-ca1992d4afe1", new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(4025), "valera@xitroo.com", true, "Valerij", false, "Jmishenko", false, null, "VALERA@XITROO.COM", "VALERAJMIH", "AQAAAAEAACcQAAAAELXM6ETOnIrNLqiksYqOZZ1tKbsO/TLM1hKXn9FCvapFZEcWYLcYxvK9rxxxDSQCSA==", "", false, "P5IWCILRLNALOGOW77G2WLTUREFC7BZG", false, "valerajmih" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(4822), false, "Jmih V.A." },
                    { 2L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5136), false, "Drozdov G.L." },
                    { 3L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5150), false, "Teodorov V.V." },
                    { 4L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5152), false, "Kovalenko S.A." },
                    { 5L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5154), false, "Gorin O.V." }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "TransactionId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(9164), false, "21847238958" },
                    { 2L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(9465), false, "" }
                });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "CreationDate", "Currency", "Description", "IsRemoved", "Price", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(5387), 6, "Neurotechnologies", false, 1000.0, "Neurotechnologies", 3 },
                    { 2L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(6525), 2, "C# Starter", false, 20.0, "C# Starter", 1 },
                    { 3L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(6568), 1, "ASP.NET MVC 5", false, 100.0, "ASP.NET MVC 5", 1 },
                    { 4L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(6570), 2, "How it works", false, 50.0, "How it works", 2 },
                    { 5L, new DateTime(2020, 10, 1, 8, 43, 15, 112, DateTimeKind.Utc).AddTicks(6572), 1, "Angular 9", false, 70.0, "Angular 9", 1 }
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
                    { 1L, new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(5832), new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(5836), "Nothing special", false, 1L, 1, 2L },
                    { 2L, new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(6733), new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(6734), "And here is nothing special", false, 2L, 2, 2L }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Amount", "Count", "CreationDate", "Currency", "IsRemoved", "OrderId", "PrintingEditionId" },
                values: new object[,]
                {
                    { 1L, 2000.0, 2, new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(7006), 6, false, 1L, 1L },
                    { 3L, 80.0, 4, new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(8469), 2, false, 1L, 2L },
                    { 4L, 500.0, 10, new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(8471), 2, false, 1L, 4L },
                    { 5L, 420.0, 6, new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(8474), 1, false, 1L, 5L },
                    { 2L, 7000.0, 7, new DateTime(2020, 10, 1, 8, 43, 15, 113, DateTimeKind.Utc).AddTicks(8407), 6, false, 2L, 1L }
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
