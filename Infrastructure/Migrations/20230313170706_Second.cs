using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreateDm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAdditives",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAdditives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAdditives_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "product",
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPriceOptions",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreateDm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPriceOptions_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "product",
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "product",
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreateDm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPriceHistories",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPriceExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreateDm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPriceHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPriceOptionValues",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProductPriceOptionId = table.Column<int>(type: "int", nullable: false),
                    CreateDm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceOptionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPriceOptionValues_ProductPriceOptions_ProductPriceOptionId",
                        column: x => x.ProductPriceOptionId,
                        principalSchema: "product",
                        principalTable: "ProductPriceOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPriceOptionValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductToProductAdditives",
                schema: "product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductAdditiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToProductAdditives", x => new { x.ProductId, x.ProductAdditiveId });
                    table.ForeignKey(
                        name: "FK_ProductToProductAdditives_ProductAdditives_ProductAdditiveId",
                        column: x => x.ProductAdditiveId,
                        principalSchema: "product",
                        principalTable: "ProductAdditives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductToProductAdditives_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPriceHistoryToOptionValues",
                schema: "product",
                columns: table => new
                {
                    ProductPriceOptionValueId = table.Column<int>(type: "int", nullable: false),
                    ProductPriceHistoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceHistoryToOptionValues", x => new { x.ProductPriceOptionValueId, x.ProductPriceHistoryId });
                    table.ForeignKey(
                        name: "FK_ProductPriceHistoryToOptionValues_ProductPriceHistories_ProductPriceHistoryId",
                        column: x => x.ProductPriceHistoryId,
                        principalSchema: "product",
                        principalTable: "ProductPriceHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPriceHistoryToOptionValues_ProductPriceOptionValues_ProductPriceOptionValueId",
                        column: x => x.ProductPriceOptionValueId,
                        principalSchema: "product",
                        principalTable: "ProductPriceOptionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdditives_ProductCategoryId",
                schema: "product",
                table: "ProductAdditives",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                schema: "product",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistories_ProductId",
                schema: "product",
                table: "ProductPriceHistories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistoryToOptionValues_ProductPriceHistoryId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                column: "ProductPriceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceOptions_ProductCategoryId",
                schema: "product",
                table: "ProductPriceOptions",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceOptionValues_ProductId",
                schema: "product",
                table: "ProductPriceOptionValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceOptionValues_ProductPriceOptionId",
                schema: "product",
                table: "ProductPriceOptionValues",
                column: "ProductPriceOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                schema: "product",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToProductAdditives_ProductAdditiveId",
                schema: "product",
                table: "ProductToProductAdditives",
                column: "ProductAdditiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductPriceHistoryToOptionValues",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductToProductAdditives",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductPriceHistories",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductPriceOptionValues",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductAdditives",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductPriceOptions",
                schema: "product");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "product");
        }
    }
}
