using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "CartProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.ProductId, x.CartId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductID, x.ImageURL });
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInfo",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInfo", x => new { x.ProductID, x.Color, x.Size });
                    table.ForeignKey(
                        name: "FK_ProductsInfo_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WishListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MidName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_WishLists_WishListID",
                        column: x => x.WishListID,
                        principalTable: "WishLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductWishList",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishListsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishList", x => new { x.ProductsId, x.WishListsId });
                    table.ForeignKey(
                        name: "FK_ProductWishList_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWishList_WishLists_WishListsId",
                        column: x => x.WishListsId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "CustomersReviews",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersReviews", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomersReviews_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardNumber", "CartID", "City", "ConcurrencyStamp", "Country", "Discriminator", "Email", "EmailConfirmed", "ExpireDate", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MidName", "NameOnCard", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "WishListID" },
                values: new object[,]
                {
                    { "07d96ed8-155d-49c7-a77a-615f109d77c3", 0, 1234567890123456m, null, "New York", "901f16f7-d759-48fd-abff-998636fb5470", "Ukraine", "Customer", "johndoe@example.com", false, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", false, null, "E", " John E Doe", null, null, null, "123-456-7890", false, "User", "ae33ba4b-d8c5-4522-bdfc-f551d8b9303f", "123 Main St", false, null, null },
                    { "0e67a2e5-df53-4a92-9854-8e1ad46a4e61", 0, 5432101234567890m, null, "Paris", "70d3d26f-5a5e-4c65-bced-d98020d8d3a1", "France", "Customer", "oliviabrown@example.com", false, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Brown", false, null, "N", "Olivia N Brown", null, null, null, "888-777-6666", false, "User", "7a8af891-0532-4f86-8892-e48a7d2dda9e", "123 Cherry St", false, null, null },
                    { "22ac8dc9-4385-48ae-90a3-7d8c898c6d5d", 0, 1234554321098765m, null, "Seoul", "7687822e-2a8e-4900-854b-360f3a01dd4b", "Serbia", "Customer", "sophialee@example.com", false, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Lee", false, null, "K", "Sophia K Lee", null, null, null, "222-333-4444", false, "User", "b4a64c76-e5d5-4e16-bc6b-a7b70d1c9192", "456 Cedar St", false, null, null },
                    { "23456789-01ab-cdef-0123-456789abcdef", 0, 5432109876543210m, null, "Madrid", "ed62e57e-28a0-4a1e-b5af-e1cd960e8541", "Spain", "Customer", "isabellatmartinez@example.com", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabella", "Martinez", false, null, "T", "Isabella T Martinez", null, null, null, "888-777-6666", false, "User", "2acae11b-ab6c-47cc-9cc4-a7ccce5884a2", "123 Cherry St", false, null, null },
                    { "2345cdef-0123-4567-89ab-cdef01234567", 0, 1234554321098765m, null, "Seattle", "95be0e83-7841-40e9-9196-1354a9be4dc3", "Kiribati", "Customer", "noahajohnson@example.com", false, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noah", "Johnson", false, null, "A", "Noah A Johnson", null, null, null, "222-333-4444", false, "User", "76b60d48-f3c1-40d2-bf09-ec4f71724287", "456 Cedar St", false, null, null },
                    { "234cdf89-12a3-45b6-789c-0123456789de", 0, 9876543298765432m, null, "New York", "8657d3dc-aa8f-4011-8820-a696fc57dbeb", "Bangladesh", "Customer", "emmajdavis@example.com", false, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "Davis", false, null, "J", "Emma J Davis", null, null, null, "444-555-6666", false, "User", "67ca2f08-89e0-4b7b-85fa-40906014e88b", "456 Maple Ave", false, null, null },
                    { "456789ab-cdef-0123-4567-89abcdef0123", 0, 5432167890123456m, null, "Rome", "7ae1fce0-9170-43f1-a248-4140c7eb0c2e", "Italy", "Customer", "miasjohnson@example.com", false, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mia", "Johnson", false, null, "S", "Mia S Johnson", null, null, null, "777-888-9999", false, "User", "d1e34b4e-4c72-4da1-9a11-3866b9a69f64", "789 Oak St", false, null, null },
                    { "56789abc-def0-1234-5678-9abcdef01234", 0, 1234987654321098m, null, "Tokyo", "563ffe1c-42bc-4698-b745-c283abdc13d9", "Japan", "Customer", "logantmartinez@example.com", false, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logan", "Martinez", false, null, "T", "Logan T Martinez", null, null, null, "555-666-7777", false, "User", "2f50d9b2-8308-4e66-b7a5-94604a177670", "123 Walnut Ave", false, null, null },
                    { "6789abcd-ef01-2345-6789-abcd01234567", 0, 1234987654321098m, null, "Los Angeles", "0a37ea4d-ad0a-4c72-b2ba-8b9fda608529", "Somalia", "Customer", "liammwilson@example.com", false, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liam", "Wilson", false, null, "M", "Liam M Wilson", null, null, null, "777-888-9999", false, "User", "43716fb9-1348-4047-87c3-8c26ef7acd16", "789 Oak St", false, null, null },
                    { "724587e6-9314-4fe6-9c3e-6fd612f50234", 0, 1234567812345678m, null, "London", "653c5e6a-b64b-43d5-a6c0-b9f9b390ccca", "Andorra", "Customer", "williamtaylor@example.com", false, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Taylor", false, null, "G", "William G Taylor", null, null, null, "111-222-3333", false, "User", "bf804a3c-fa95-4e61-b31f-739ee8cb9276", "123 Elm St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992b58", 0, 5432167890123456m, null, "Chicago", "f8097a45-4bda-4c4c-ab7c-7ee6fd58dbe3", "Zimbabwe", "Customer", "alexjohnson@example.com", false, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "Johnson", false, null, "S", " Alex S Johnson", null, null, null, "777-888-666", false, "User", "cfbfff43-234e-4ece-a766-c5b2bcb60cc1", "789 Oak St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7", 0, 9876543210123456m, null, "San Francisco", "a53fa270-5002-4e58-8920-f34ca391bd97", "Australia", "Customer", "emilyanderson@example.com", false, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Anderson", false, null, "R", "Emily R Anderson", null, null, null, "111-222-3333", false, "User", "d97a82c9-303a-4673-b2b6-6b2d56f18b57", "789 Elm St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8", 0, 1234987654321098m, null, "London", "08d75039-21d2-4353-8cb8-8b0211a7e7bf", "Albania", "Customer", "michaelwilson@example.com", false, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Wilson", false, null, "J", "Michael J Wilson", null, null, null, "444-555-6666", false, "User", "31f5811d-3b18-4bea-980d-0af7f5fefa36", "456 Maple Ave", false, null, null },
                    { "8901def0-1234-5678-9abc-def012345678", 0, 9876543298765432m, null, "San Francisco", "bb2da114-e802-4ae9-81c3-4f1621030f35", "Uruguay", "Customer", "avaklee@example.com", false, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ava", "Lee", false, null, "K", "Ava K Lee", null, null, null, "555-666-7777", false, "User", "32f18dc3-aa90-4bdf-acfd-c9355d5f6b33", "789 Walnut Ave", false, null, null },
                    { "b6a76b15-33e5-4d26-98b9-c948c7823b84", 0, 9876543210012345m, null, "Madrid", "eae79606-91ba-4d87-aead-793c382dc487", "Spain", "Customer", "danielmartinez@example.com", false, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Martinez", false, null, "T", "Daniel T Martinez", null, null, null, "555-666-7777", false, "User", "ee5170c9-d1c5-418f-ba1d-306ab8198140", "789 Walnut Ave", false, null, null },
                    { "bcdef012-3456-789a-bcde-f01234567890", 0, 9876012345678901m, null, "Sydney", "3822bb6a-ac1e-4e0d-b196-f2de89129435", "Australia", "Customer", "olivialthompson@example.com", false, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Thompson", false, null, "L", "Olivia L Thompson", null, null, null, "777-777-8888", false, "User", "5f847093-3730-4b61-a67d-a88c7745f13f", "123 Pine St", false, null, null },
                    { "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0, 9876543210987654m, null, "Los Angeles", "d69dfcca-fb57-4fef-bddd-6bcd959f3528", "Turkey", "Customer", "janesmith@example.com", false, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", false, null, "A", " Jane A Smith", null, null, null, "777-888-9999", false, "User", "7ebbaff5-9f01-4a3c-8827-e44e611ac3e5", "456 Elm St", false, null, null },
                    { "def01234-5678-9abc-def0-123456789abc", 0, 1234567812345678m, null, "Paris", "abf1096f-7f11-498b-ba99-c11799dbe4eb", "France", "Customer", "sophianbrown@example.com", false, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Brown", false, null, "N", "Sophia N Brown", null, null, null, "999-888-7777", false, "User", "0171db6b-1012-4a2e-8d16-bbeca8b7c366", "456 Maple Ave", false, null, null },
                    { "e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc", 0, 9876012345678901m, null, "Sydney", "220bb7b5-1efc-41f7-bf92-a3425e93d627", "Australia", "Customer", "sarahthompson@example.com", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "Thompson", false, null, "L", "Sarah L Thompson", null, null, null, "777-777-8888", false, "User", "2dd96a38-4b70-4789-a1ce-1471782ec9a7", "789 Pine St", false, null, null },
                    { "f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f", 0, 5432109876543210m, null, "Toronto", "a5af1728-00ad-433d-a37d-48388f4c228f", "Canada", "Customer", "davidmiller@example.com", false, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Miller", false, null, "M", "David M Miller", null, null, null, "999-888-7777", false, "User", "eb3f8e0b-b2fc-4d72-b886-2828de973469", "123 Oak Ave", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("08c139d4-c4c6-47ed-a26a-a6c1444d5c45"), new Guid("c7d3e80a-7a4a-4c54-91a6-89c0df051c94") },
                    { new Guid("2577a20e-adb9-49e3-993b-603bec966a18"), new Guid("b6a76b15-33e5-4d26-98b9-c948c7823b84") },
                    { new Guid("3c8da74f-f37c-4a51-a6aa-76bbcd3d3dc4"), new Guid("def01234-5678-9abc-def0-123456789abc") },
                    { new Guid("400b06a5-93c2-40b9-8f9d-41e421c91151"), new Guid("0e67a2e5-df53-4a92-9854-8e1ad46a4e61") },
                    { new Guid("5f36fa5c-41a2-4dab-a7f3-11b493635932"), new Guid("8901def0-1234-5678-9abc-def012345678") },
                    { new Guid("7e510317-3cf8-465e-aeaa-a873c89e5d73"), new Guid("bcdef012-3456-789a-bcde-f01234567890") },
                    { new Guid("8521a8b2-06c6-4084-93b7-8d06ddf1c701"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7") },
                    { new Guid("9e4b7852-f663-4779-9d96-bf68957d1532"), new Guid("2345cdef-0123-4567-89ab-cdef01234567") },
                    { new Guid("9fd9925c-9d3e-4843-ac0b-d7b768e99a8e"), new Guid("e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc") },
                    { new Guid("a0aa7b28-db53-4eec-858d-ba5aaa598f0c"), new Guid("23456789-01ab-cdef-0123-456789abcdef") },
                    { new Guid("a4354553-817c-419e-818c-7e37cc85ee52"), new Guid("6789abcd-ef01-2345-6789-abcd01234567") },
                    { new Guid("acd8bec4-9435-420d-b56d-6a3556919ea1"), new Guid("724587e6-9314-4fe6-9c3e-6fd612f50234") },
                    { new Guid("ce036e14-a1ae-464d-b187-f09b9f224432"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992b58") },
                    { new Guid("d493bf27-b432-4e8d-b4b5-93de4b486864"), new Guid("22ac8dc9-4385-48ae-90a3-7d8c898c6d5d") },
                    { new Guid("d6f10021-39f0-47f7-b4f6-89fa266481f8"), new Guid("234cdf89-12a3-45b6-789c-0123456789de") },
                    { new Guid("e0e01361-538e-4d9f-862b-575f9d0d978e"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8") },
                    { new Guid("eb702766-dd54-45f4-ab27-785f74b94fdd"), new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f"), "Kids's Clothing", "Kids.jpg", "Kids", null },
                    { new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d"), "Women's Clothing", "Women.jpg", "Women", null },
                    { new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583"), "Men's Clothing", "men.jpg", "Men", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discount", "Name", "Price", "Rate" },
                values: new object[,]
                {
                    { new Guid("04c9017f-54c8-4b7a-9005-891935fa118a"), "Stylish jacket for women", 0m, "Women's Jacket", 54.99m, 0m },
                    { new Guid("0615666c-51ae-43da-baf6-af4fe1d644fd"), "Casual t-shirt for women", 0.2m, "Women's T-Shirt", 19.99m, 0m },
                    { new Guid("0665fdca-a4f6-4e59-8bdf-aa89e27589bc"), "Warm sweater for kids", 0m, "Kids' Sweater", 34.99m, 0m },
                    { new Guid("08d7fefa-56ff-47e9-8abc-6b48bd025949"), "Comfortable shorts for men", 0m, "Men's Shorts", 24.99m, 0m },
                    { new Guid("1383d648-8cb3-4289-830d-088ee8749682"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("18834b0d-3e2b-4378-b1df-25341ce732f4"), "Casual shorts for men", 0.1m, "Men's Shorts", 17.99m, 0m },
                    { new Guid("1933a740-9827-4a34-ae50-73c542ecdaf6"), "Casual shorts for kids", 0m, "Kids' Shorts", 15.99m, 0m },
                    { new Guid("1fead0fa-6811-4596-a93e-69d931219c77"), "Classic denim jeans for men", 0.05m, "Men's Jeans", 39.99m, 0m },
                    { new Guid("21998760-fe38-4b3f-81f8-931ba21c8da4"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("23733e49-a32c-48bc-9211-b48feca50263"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("2c99c878-415d-4106-aedf-d631283dae2a"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("36f892f3-4487-4b75-a88f-0c90e0ee3f45"), "Comfortable sandals for women", 0.2m, "Women's Sandals", 34.99m, 0m },
                    { new Guid("3ead5485-b8a7-4377-be09-53054bd002e8"), "Stylish trousers for kids", 0.05m, "Kids' Trousers", 34.99m, 0m },
                    { new Guid("427e0019-8009-4578-b34c-7ea52fd311ba"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("4e16340c-5ab1-4dc9-8bcc-ff9641e6b537"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("516a9a73-df2e-45eb-8d5c-ac53645d6574"), "Elegant blazer for women", 0.2m, "Women's Blazer", 59.99m, 0m },
                    { new Guid("5d8a015b-01e3-46f9-8497-d99a02d2ab07"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("63903add-86c3-4d2f-8021-27a86a7bcf59"), "Cozy sweater for women", 0m, "Women's Sweater", 39.99m, 0m },
                    { new Guid("6630af75-cefa-4d71-92ef-9eb910f63321"), "Cute dress for kids", 0m, "Kids' Dress", 32.99m, 0m },
                    { new Guid("6a852b98-204a-4137-8455-11c713533750"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("847ff397-c982-4fee-97a4-c375025b9486"), "Stylish sneakers for men", 0.15m, "Men's Sneakers", 59.99m, 0m },
                    { new Guid("8b08778f-9d8c-4228-9f94-408ec300fb79"), "Stylish blouse for women", 0m, "Women's Blouse", 24.99m, 0m },
                    { new Guid("94f029b8-d502-493e-9e41-83c16fa6d05d"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("95c44ed4-7f69-4358-a0b9-5097df631a3d"), "Casual trousers for kids", 0.1m, "Kids' Trousers", 21.99m, 0m },
                    { new Guid("972fd402-8b31-429a-b780-2f605c4c4c96"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("9d4493b1-b23c-4f3f-a6a3-b33162bfb9fd"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("a0808f81-a925-4a05-b5c3-fdf8d0a85366"), "Spacious backpack for kids", 0m, "Kids' Backpack", 19.99m, 0m },
                    { new Guid("aa8dbe6b-6aeb-4b7b-ab93-4c6d53242e6b"), "Sporty sneakers for women", 0m, "Women's Sneakers", 49.99m, 0m },
                    { new Guid("ab1e26e4-508f-45a2-8497-0ef448f1ef2a"), "Adorable t-shirt for kids", 0m, "Kids' T-Shirt", 12.99m, 0m },
                    { new Guid("c2d79b90-fb63-49f5-89d9-cfc033df6fe6"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("c517ab5c-311d-4a0e-a73f-a0946eb0ee25"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("d0cc568d-f2f5-4db4-b431-9a60a51c43e3"), "Warm jacket for kids", 0.1m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("d1822590-4e78-45e2-b601-e4ec78ecdbee"), "Adorable shirt for kids", 0.15m, "Kids' Shirt", 17.99m, 0m },
                    { new Guid("d66f6447-b1b7-4ca1-af2e-5c3581a85e0d"), "Sporty sneakers for men", 0.1m, "Men's Sneakers", 54.99m, 0m },
                    { new Guid("d9b6e6f6-f3ec-4374-a40d-aa543f9f94fe"), "Fashionable sandals for women", 0.1m, "Women's Sandals", 29.99m, 0m },
                    { new Guid("dd4fe700-2d01-4010-8149-9fdfec5fef77"), "Warm sweater for men", 0.1m, "Men's Sweater", 39.99m, 0m },
                    { new Guid("e315499c-8bbb-4bf9-a92f-46bdbb6167a5"), "Stylish denim jeans for women", 0.05m, "Women's Jeans", 44.99m, 0m },
                    { new Guid("e4e20f23-ec2e-4259-b550-91bde9c2b42d"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("f09a3bb6-2af5-4421-b707-1d833b18471d"), "Classic polo shirt for men", 0m, "Men's Polo Shirt", 22.99m, 0m },
                    { new Guid("f627d1d9-64b1-4822-94c6-7e03e2fe44e3"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("1d53debe-03e6-487f-9b34-6b26c68fc1e5"), "Kids Pants's Clothing", "Kids Pants.jpg", "Pants", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("35b303b9-25a0-4379-89b3-64e4ae51291f"), "Women Shoes's Clothing", "Women Shoes.jpg", "Shoes", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("47a38a48-8747-4461-ba32-7e573be663ee"), "Women Jackets's Clothing", "Women Jackets.jpg", "Jackets", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("6b3c4ef5-01ad-49c7-a8ff-36ae55d0ce8d"), "Men Shoes's Clothing", "men Shoes.jpg", "Shoes", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("6f6c6c4c-9e6e-4e0c-97cc-8b52c055918b"), "Men Jackets's Clothing", "men Jackets.jpg", "Jackets", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("8a6d4a19-47cc-4a4e-822b-cac1de2efc8d"), "Kids shirts's Clothing", "Kids shirts.jpg", "Shirts", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("9a938bc1-0717-4b8d-8f8b-3a2f55de49db"), "Men Pants's Clothing", "men Pants.jpg", "Pants", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("a6c4de53-33c5-48e1-9f21-5649726d3a3d"), "Women shirts's Clothing", "Women shirts.jpg", "Shirts", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("a6d7e8b5-2f4d-4f51-b24b-4fcb52e36f5f"), "Men Hoodies's Clothing", "men Hoodies.jpg", "Hoodies", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("b19a53a3-04e7-4804-84bc-84da64d738a6"), "Kids Jackets's Clothing", "Kids Jackets.jpg", "Jackets", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("c2ae51c9-913a-4e7d-a7b5-ef1efc8f9d3e"), "Kids Hoodies's Clothing", "Kids Hoodies.jpg", "Hoodies", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("ca09f6a1-5b87-4b56-9ee3-c6fb6ad070c2"), "Kids Shoes's Clothing", "Kids Shoes.jpg", "Shoes", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("d9f02e92-d14c-4b6d-86ad-6e4e6c48020a"), "Women Pants's Clothing", "Women Pants.jpg", "Pants", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("e18e42b7-799e-4b3b-a084-c55d4bb5da3f"), "Women Hoodies's Clothing", "Women Hoodies.jpg", "Hoodies", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("f032f788-2340-431f-9f8f-eeb176a35177"), "Mens shirts's Clothing", "men shirts.jpg", "Shirts", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArrivalDate", "City", "Country", "CustomerId", "Discount", "OrderData", "OrderStatus", "PaymentMethod", "PaymentStatus", "Street" },
                values: new object[,]
                {
                    { new Guid("07d96ed8-155d-49c7-a77a-615f109d75c3"), new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Zimbabwe", "b6a76b15-33e5-4d26-98b9-c948c7823b84", 1.0, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "789 Oak St" },
                    { new Guid("07d96ed8-155d-49c7-a77a-615f109d77c3"), new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Zimbabwe", "e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc", 1.0, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "789 Oak St" },
                    { new Guid("0e67a2e5-df53-4a92-9854-8e1ad46a4e61"), new DateTime(2027, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York", "Belgium", "0e67a2e5-df53-4a92-9854-8e1ad46a4e61", 0.0, new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Unpaid", "123 Elm St" },
                    { new Guid("22ac8dc9-4385-48ae-90a3-7d8c898c6d5d"), new DateTime(2027, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles", "Belize", "74f5b2b3-3d10-4a85-93b5-8c6d0c992b58", 0.5, new DateTime(2027, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped", "CashOnDelivery", "Paid", "456 Main St" },
                    { new Guid("23456789-01ab-cdef-0123-456789abcdef"), new DateTime(2027, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Oman", "234cdf89-12a3-45b6-789c-0123456789de", 0.10000000000000001, new DateTime(2027, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "321 Maple Ave" },
                    { new Guid("2345cdef-0123-4567-89ab-cdef11234567"), new DateTime(2027, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Taiwan", "6789abcd-ef01-2345-6789-abcd01234567", 0.20000000000000001, new DateTime(2027, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Paid", "567 Pine St" },
                    { new Guid("6789abcd-ef01-2345-6789-abcd01234567"), new DateTime(2029, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Libya", "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0.20000000000000001, new DateTime(2029, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Paid", "789 Elm St" },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50232"), new DateTime(2029, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Senegal", "def01234-5678-9abc-def0-123456789abc", 0.29999999999999999, new DateTime(2029, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "123 Maple Ave" },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50233"), new DateTime(2029, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Samoa", "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0.20000000000000001, new DateTime(2029, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "789 Pine St" },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50234"), new DateTime(2029, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dallas", "Samoa", "b6a76b15-33e5-4d26-98b9-c948c7823b84", 0.10000000000000001, new DateTime(2029, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "987 Cedar St" },
                    { new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992b58"), new DateTime(2029, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Diego", "Samoa", "bcdef012-3456-789a-bcde-f01234567890", 0.0, new DateTime(2029, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Unpaid", "456 Oak St" },
                    { new Guid("8901def0-1234-5678-9abc-def012345678"), new DateTime(2029, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Afghanistan", "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7", 0.0, new DateTime(2029, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Unpaid", "123 Pine St" },
                    { new Guid("b6a76b15-33e5-4d26-98b9-c948c7823b84"), new DateTime(2029, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles", "Andorra", "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8", 0.10000000000000001, new DateTime(2029, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "456 Maple Ave" },
                    { new Guid("c7d3e80a-7a4a-4c54-91a6-89c0df051c94"), new DateTime(2029, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Iraq", "07d96ed8-155d-49c7-a77a-615f109d77c3", 0.10000000000000001, new DateTime(2029, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "567 Oak St" },
                    { new Guid("def01234-5678-9abc-def0-113456789abc"), new DateTime(2028, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miami", "Fiji", "bcdef012-3456-789a-bcde-f01234567890", 0.29999999999999999, new DateTime(2028, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "901 Cherry Ln" },
                    { new Guid("e23edc32-bd6a-4b6b-a28e-ccf90b5c32dc"), new DateTime(2028, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boston", "Denmark", "2345cdef-0123-4567-89ab-cdef01234567", 0.14999999999999999, new DateTime(2028, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "246 Elm St" },
                    { new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f"), new DateTime(2029, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Canada", "724587e6-9314-4fe6-9c3e-6fd612f50234", 0.20000000000000001, new DateTime(2028, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Unpaid", "789 Elm St" },
                    { new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b5c7c49f"), new DateTime(2029, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Canada", "8901def0-1234-5678-9abc-def012345678", 0.20000000000000001, new DateTime(2029, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Unpaid", "789 Elm St" }
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
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WishListID",
                table: "AspNetUsers",
                column: "WishListID",
                unique: true,
                filter: "[WishListID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersReviews_CustomerId",
                table: "CustomersReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWishList_WishListsId",
                table: "ProductWishList",
                column: "WishListsId");
        }

        /// <inheritdoc />
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
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CustomersReviews");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductsInfo");

            migrationBuilder.DropTable(
                name: "ProductWishList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "WishLists");
        }
    }
}
