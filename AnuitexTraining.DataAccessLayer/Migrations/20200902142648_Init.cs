using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnuitexTraining.DataAccessLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Authors",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Authors", x => x.Id); });

            migrationBuilder.CreateTable(
                "Payments",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Payments", x => x.Id); });

            migrationBuilder.CreateTable(
                "PrintingEditions",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_PrintingEditions", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
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
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
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
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Orders",
                table => new
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
                        "FK_Orders_Payments_PaymentId",
                        x => x.PaymentId,
                        "Payments",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Orders_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AuthorInPrintingEditions",
                table => new
                {
                    AuthorId = table.Column<long>(nullable: false),
                    PrintingEditionId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorInPrintingEditions", x => new {x.AuthorId, x.PrintingEditionId});
                    table.ForeignKey(
                        "FK_AuthorInPrintingEditions_Authors_AuthorId",
                        x => x.AuthorId,
                        "Authors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId",
                        x => x.PrintingEditionId,
                        "PrintingEditions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "OrderItems",
                table => new
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
                        "FK_OrderItems_Orders_OrderId",
                        x => x.OrderId,
                        "Orders",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_OrderItems_PrintingEditions_PrintingEditionId",
                        x => x.PrintingEditionId,
                        "PrintingEditions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "AspNetRoles",
                new[] {"Id", "ConcurrencyStamp", "Name", "NormalizedName"},
                new object[,]
                {
                    {1L, "f91f0bcb-0397-47c2-8fe5-0f30591adae8", "Admin", null},
                    {2L, "8b2c86df-17b1-4dee-a9fa-019d51d4246d", "Client", null}
                });

            migrationBuilder.InsertData(
                "AspNetUsers",
                new[]
                {
                    "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed",
                    "FirstName", "IsBlocked", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail",
                    "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp",
                    "TwoFactorEnabled", "UserName"
                },
                new object[,]
                {
                    {
                        1L, 0, "beae8a3d-6016-4c46-b746-8a301bbba2fa",
                        new DateTime(2020, 9, 2, 14, 26, 47, 312, DateTimeKind.Utc).AddTicks(1610),
                        "vladiator@xitroo.com", true, "Vladislav", false, "Goncharuk", false, null,
                        "VLADIATOR@XITROO.COM", "VLADIATOR",
                        "AQAAAAEAACcQAAAAEKHk3sTABbsMTgCaH81KcsHXbNSfveaBeQYBbLM8tOS5EKut5YWZcDbh7uCXUARPmQ==", null,
                        false, "UD6OIMX72OWACSZNP6QXRDB6AK5UAQWK", false, "vladiator"
                    },
                    {
                        2L, 0, "4734878e-90f7-4970-88c1-baf58e73f94f",
                        new DateTime(2020, 9, 2, 14, 26, 47, 312, DateTimeKind.Utc).AddTicks(1704), "valera@xitroo.com",
                        true, "Valerij", false, "Jmishenko", false, null, "VALERA@XITROO.COM", "VALERAJMIH",
                        "AQAAAAEAACcQAAAAELXM6ETOnIrNLqiksYqOZZ1tKbsO/TLM1hKXn9FCvapFZEcWYLcYxvK9rxxxDSQCSA==", null,
                        false, "P5IWCILRLNALOGOW77G2WLTUREFC7BZG", false, "valerajmih"
                    }
                });

            migrationBuilder.InsertData(
                "Authors",
                new[] {"Id", "CreationDate", "IsRemoved", "Name"},
                new object[,]
                {
                    {
                        1L, new DateTime(2020, 9, 2, 14, 26, 47, 310, DateTimeKind.Utc).AddTicks(6816), false,
                        "Jmih V.A."
                    },
                    {
                        2L, new DateTime(2020, 9, 2, 14, 26, 47, 310, DateTimeKind.Utc).AddTicks(7309), false,
                        "Drozdov G.L."
                    },
                    {
                        3L, new DateTime(2020, 9, 2, 14, 26, 47, 310, DateTimeKind.Utc).AddTicks(7317), false,
                        "Teodorov V.V."
                    },
                    {
                        4L, new DateTime(2020, 9, 2, 14, 26, 47, 310, DateTimeKind.Utc).AddTicks(7319), false,
                        "Kovalenko S.A."
                    },
                    {
                        5L, new DateTime(2020, 9, 2, 14, 26, 47, 310, DateTimeKind.Utc).AddTicks(7321), false,
                        "Gorin O.V."
                    }
                });

            migrationBuilder.InsertData(
                "Payments",
                new[] {"Id", "CreationDate", "IsRemoved", "TransactionId"},
                new object[,]
                {
                    {
                        1L, new DateTime(2020, 9, 2, 14, 26, 47, 311, DateTimeKind.Utc).AddTicks(4094), false,
                        "21847238958"
                    },
                    {2L, new DateTime(2020, 9, 2, 14, 26, 47, 311, DateTimeKind.Utc).AddTicks(4543), false, ""}
                });

            migrationBuilder.InsertData(
                "PrintingEditions",
                new[] {"Id", "CreationDate", "Currency", "Description", "IsRemoved", "Price", "Title", "Type"},
                new object[,]
                {
                    {
                        1L, new DateTime(2020, 9, 2, 14, 26, 47, 310, DateTimeKind.Utc).AddTicks(7734), 6,
                        "Neurotechnologies", false, 1000.0, "Neurotechnologies", 3
                    },
                    {
                        2L, new DateTime(2020, 9, 2, 14, 26, 47, 311, DateTimeKind.Utc).AddTicks(1672), 2, "C# Starter",
                        false, 20.0, "C# Starter", 1
                    },
                    {
                        3L, new DateTime(2020, 9, 2, 14, 26, 47, 311, DateTimeKind.Utc).AddTicks(1741), 1,
                        "ASP.NET MVC 5", false, 100.0, "ASP.NET MVC 5", 1
                    },
                    {
                        4L, new DateTime(2020, 9, 2, 14, 26, 47, 311, DateTimeKind.Utc).AddTicks(1744), 2,
                        "How it works", false, 50.0, "How it works", 2
                    },
                    {
                        5L, new DateTime(2020, 9, 2, 14, 26, 47, 311, DateTimeKind.Utc).AddTicks(1749), 1, "Angular 9",
                        false, 70.0, "Angular 9", 1
                    }
                });

            migrationBuilder.InsertData(
                "AspNetUserRoles",
                new[] {"UserId", "RoleId"},
                new object[,]
                {
                    {1L, 1L},
                    {2L, 2L}
                });

            migrationBuilder.InsertData(
                "AuthorInPrintingEditions",
                new[] {"AuthorId", "PrintingEditionId", "Date"},
                new object[,]
                {
                    {1L, 1L, new DateTime(2008, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)},
                    {2L, 2L, new DateTime(2010, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)},
                    {3L, 3L, new DateTime(2016, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)},
                    {4L, 4L, new DateTime(2002, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)},
                    {5L, 5L, new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)}
                });

            migrationBuilder.InsertData(
                "Orders",
                new[]
                    {"Id", "CreationDate", "Date", "Description", "IsRemoved", "PaymentId", "Status", "UserId"},
                new object[,]
                {
                    {
                        1L, new DateTime(2020, 9, 2, 14, 26, 47, 312, DateTimeKind.Utc).AddTicks(6603),
                        new DateTime(2020, 9, 2, 14, 26, 47, 312, DateTimeKind.Utc).AddTicks(6607), "Nothing special",
                        false, 1L, 1, 2L
                    },
                    {
                        2L, new DateTime(2020, 9, 2, 14, 26, 47, 312, DateTimeKind.Utc).AddTicks(9263),
                        new DateTime(2020, 9, 2, 14, 26, 47, 312, DateTimeKind.Utc).AddTicks(9264),
                        "And here is nothing special", false, 2L, 2, 2L
                    }
                });

            migrationBuilder.InsertData(
                "OrderItems",
                new[]
                    {"Id", "Amount", "Count", "CreationDate", "Currency", "IsRemoved", "OrderId", "PrintingEditionId"},
                new object[,]
                {
                    {
                        1L, 2000.0, 2, new DateTime(2020, 9, 2, 14, 26, 47, 312, DateTimeKind.Utc).AddTicks(9783), 6,
                        false, 1L, 1L
                    },
                    {
                        3L, 80.0, 4, new DateTime(2020, 9, 2, 14, 26, 47, 313, DateTimeKind.Utc).AddTicks(2962), 2,
                        false, 1L, 2L
                    },
                    {
                        4L, 500.0, 10, new DateTime(2020, 9, 2, 14, 26, 47, 313, DateTimeKind.Utc).AddTicks(2965), 2,
                        false, 1L, 4L
                    },
                    {
                        5L, 420.0, 6, new DateTime(2020, 9, 2, 14, 26, 47, 313, DateTimeKind.Utc).AddTicks(2967), 1,
                        false, 1L, 5L
                    },
                    {
                        2L, 7000.0, 7, new DateTime(2020, 9, 2, 14, 26, 47, 313, DateTimeKind.Utc).AddTicks(2879), 6,
                        false, 2L, 1L
                    }
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AuthorInPrintingEditions_PrintingEditionId",
                "AuthorInPrintingEditions",
                "PrintingEditionId");

            migrationBuilder.CreateIndex(
                "IX_OrderItems_OrderId",
                "OrderItems",
                "OrderId");

            migrationBuilder.CreateIndex(
                "IX_OrderItems_PrintingEditionId",
                "OrderItems",
                "PrintingEditionId");

            migrationBuilder.CreateIndex(
                "IX_Orders_PaymentId",
                "Orders",
                "PaymentId");

            migrationBuilder.CreateIndex(
                "IX_Orders_UserId",
                "Orders",
                "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "AuthorInPrintingEditions");

            migrationBuilder.DropTable(
                "OrderItems");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "Authors");

            migrationBuilder.DropTable(
                "Orders");

            migrationBuilder.DropTable(
                "PrintingEditions");

            migrationBuilder.DropTable(
                "Payments");

            migrationBuilder.DropTable(
                "AspNetUsers");
        }
    }
}