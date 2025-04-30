using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    MinimumUnits = table.Column<int>(type: "integer", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    BarCodeGTIN = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    SellerCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Price_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    BranchUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    RecommendedSellerCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Information = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Cancelled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CancelledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Open = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    ClosedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Users_BranchUserId",
                        column: x => x.BranchUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PurchaseOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PriceId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    FullPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProduct_Price_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProduct_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProduct_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    RecommendedSellerCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Information = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Cancelled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CancelledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Open = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    ClosedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Users_BranchUserId",
                        column: x => x.BranchUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Users_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PriceId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    FullPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Price_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_PurchaseOrder_SaleId",
                        column: x => x.SaleId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9d84f0d1-38fa-473a-a06f-2281ca179f51"), new DateTime(2025, 4, 30, 0, 59, 2, 791, DateTimeKind.Utc).AddTicks(7392), "mail@mail.com", "branch 2", "1111111111", null },
                    { new Guid("e46bb862-2076-4d46-9155-749f48648f2e"), new DateTime(2025, 4, 30, 0, 59, 2, 791, DateTimeKind.Utc).AddTicks(7389), "mail@mail.com", "branch 1", "1111111111", null }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("605b5fa5-3b1c-4b25-92de-1c46ffe19fa1"), new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(109), "mail@mail.com", "customer 2", "1111111111", null },
                    { new Guid("b92201f4-b459-45d5-9ef3-1d9455bf123f"), new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(111), "mail@mail.com", "customer 3", "1111111111", null },
                    { new Guid("d78d9a8d-bbc1-46c3-b4c3-0a2798f74c40"), new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(107), "mail@mail.com", "customer 1", "1111111111", null }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "CreatedAt", "DiscountPercentage", "MinimumUnits", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("17c2e1f1-94f9-4d00-bab0-8273aee78790"), new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(2403), 20m, 10, null },
                    { new Guid("b551c293-bb06-4dc4-ae9b-bc4ab7e5fef9"), new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(2406), 0m, 21, null },
                    { new Guid("f0fa1ae7-2801-44ef-8402-5ea4d0c7f8c6"), new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(2401), 10m, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BarCodeGTIN", "Code", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8c4de8ee-752d-4628-98d2-c4e41ba4d871"), "7891991000840", "1201048", new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(7226), "Agua Tonica", "Agua Tonica Lata 350Ml Antartica", null },
                    { new Guid("996c81d9-6726-471b-9e47-8b1009e0691b"), "7891042000201", "1121285", new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(7233), "Cha gelado", "Cha Tea Zero 1,5Lt Lipton Limao", null },
                    { new Guid("ff41c778-3de5-4148-a71b-31babac65964"), "7892840822019", "1277098", new DateTime(2025, 4, 30, 0, 59, 2, 792, DateTimeKind.Utc).AddTicks(7235), "Isotonico", "Isotonico Gatorade 500Ml Blueberry", null }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8b3310f7-05cb-4530-917b-f7824edf8584"), new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(21), "Package", "PC" },
                    { new Guid("b2b8cb3c-b60e-44b1-a494-f5ce9fad92e1"), new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(19), "Unit", "UN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BranchId", "CreatedAt", "CustomerId", "Email", "Password", "Phone", "Role", "SellerCode", "Status", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("41e3de69-4265-43c6-a2d1-9657979160d2"), null, new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3287), null, "developer@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Admin", "", "Active", null, "developer" },
                    { new Guid("d7081c09-0bba-4728-b4e5-804c73a6d1b8"), null, new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3290), null, "admin@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Admin", "", "Active", null, "admin" },
                    { new Guid("f16dcf3f-c13c-413a-a73d-cc297c0e53a0"), null, new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3292), null, "manager@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Manager", "", "Active", null, "manager" },
                    { new Guid("24315cc0-f77d-48ae-a0c1-56cfa851491a"), new Guid("e46bb862-2076-4d46-9155-749f48648f2e"), new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3294), null, "branch1user1@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Branch", "", "Active", null, "branch1-user1" },
                    { new Guid("51372e2d-00ed-475f-9cbb-f8debff265b4"), null, new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3305), new Guid("d78d9a8d-bbc1-46c3-b4c3-0a2798f74c40"), "customer1user1@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Customer", "", "Active", null, "customer1-user1" },
                    { new Guid("5640e90f-ddc7-497f-821e-7aff79c34238"), null, new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3308), new Guid("d78d9a8d-bbc1-46c3-b4c3-0a2798f74c40"), "customer1user2@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Customer", "", "Active", null, "customer1-user2" },
                    { new Guid("8320f1b2-32a2-409f-88df-bd60a83723de"), null, new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3311), new Guid("605b5fa5-3b1c-4b25-92de-1c46ffe19fa1"), "customer2user1@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Customer", "", "Active", null, "customer2-user1" },
                    { new Guid("98004d1c-87c7-40d4-b873-43aa8524bbf7"), new Guid("e46bb862-2076-4d46-9155-749f48648f2e"), new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3299), null, "branch1user2@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Branch", "", "Active", null, "branch1-user2" },
                    { new Guid("a28d70c5-1b17-4913-87e6-e1e18f65571b"), null, new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3313), new Guid("b92201f4-b459-45d5-9ef3-1d9455bf123f"), "customer3user1@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Customer", "", "Active", null, "customer3-user1" },
                    { new Guid("f43616fd-c39e-40aa-b57f-b97c3937d849"), new Guid("9d84f0d1-38fa-473a-a06f-2281ca179f51"), new DateTime(2025, 4, 30, 0, 59, 2, 795, DateTimeKind.Utc).AddTicks(3303), null, "branch2user1@mail.com", "$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.", "1111111111", "Branch", "", "Active", null, "branch2-user1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Price_ProductId",
                table: "Price",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_UnitId",
                table: "Price",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_BranchId",
                table: "PurchaseOrder",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_BranchUserId",
                table: "PurchaseOrder",
                column: "BranchUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_CustomerId",
                table: "PurchaseOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProduct_PriceId",
                table: "PurchaseOrderProduct",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProduct_ProductId",
                table: "PurchaseOrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProduct_PurchaseOrderId",
                table: "PurchaseOrderProduct",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProduct_UnitId",
                table: "PurchaseOrderProduct",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BranchId",
                table: "Sale",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BranchUserId",
                table: "Sale",
                column: "BranchUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerId",
                table: "Sale",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerUserId",
                table: "Sale",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_PurchaseOrderId",
                table: "Sale",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_PriceId",
                table: "SaleProduct",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_ProductId",
                table: "SaleProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_SaleId",
                table: "SaleProduct",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_UnitId",
                table: "SaleProduct",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                table: "Users",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "PurchaseOrderProduct");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
