using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thrid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceHistoryToOptionValues_ProductPriceHistories_ProductPriceHistoryId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceHistoryToOptionValues_ProductPriceOptionValues_ProductPriceOptionValueId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceOptions_ProductCategories_ProductCategoryId",
                schema: "product",
                table: "ProductPriceOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceOptionValues_Products_ProductId",
                schema: "product",
                table: "ProductPriceOptionValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductPriceOptionValues_ProductId",
                schema: "product",
                table: "ProductPriceOptionValues");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "product",
                table: "ProductPriceOptionValues");

            migrationBuilder.RenameColumn(
                name: "ProductPriceHistoryId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                newName: "ProductPriceOptionValuesId");

            migrationBuilder.RenameColumn(
                name: "ProductPriceOptionValueId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                newName: "ProductPriceHistoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPriceHistoryToOptionValues_ProductPriceHistoryId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                newName: "IX_ProductPriceHistoryToOptionValues_ProductPriceOptionValuesId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                schema: "product",
                table: "ProductPriceOptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceHistoryToOptionValues_ProductPriceHistories_ProductPriceHistoriesId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                column: "ProductPriceHistoriesId",
                principalSchema: "product",
                principalTable: "ProductPriceHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceHistoryToOptionValues_ProductPriceOptionValues_ProductPriceOptionValuesId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                column: "ProductPriceOptionValuesId",
                principalSchema: "product",
                principalTable: "ProductPriceOptionValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceOptions_ProductCategories_ProductCategoryId",
                schema: "product",
                table: "ProductPriceOptions",
                column: "ProductCategoryId",
                principalSchema: "product",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceHistoryToOptionValues_ProductPriceHistories_ProductPriceHistoriesId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceHistoryToOptionValues_ProductPriceOptionValues_ProductPriceOptionValuesId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceOptions_ProductCategories_ProductCategoryId",
                schema: "product",
                table: "ProductPriceOptions");

            migrationBuilder.RenameColumn(
                name: "ProductPriceOptionValuesId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                newName: "ProductPriceHistoryId");

            migrationBuilder.RenameColumn(
                name: "ProductPriceHistoriesId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                newName: "ProductPriceOptionValueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPriceHistoryToOptionValues_ProductPriceOptionValuesId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                newName: "IX_ProductPriceHistoryToOptionValues_ProductPriceHistoryId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "product",
                table: "ProductPriceOptionValues",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                schema: "product",
                table: "ProductPriceOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceOptionValues_ProductId",
                schema: "product",
                table: "ProductPriceOptionValues",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceHistoryToOptionValues_ProductPriceHistories_ProductPriceHistoryId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                column: "ProductPriceHistoryId",
                principalSchema: "product",
                principalTable: "ProductPriceHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceHistoryToOptionValues_ProductPriceOptionValues_ProductPriceOptionValueId",
                schema: "product",
                table: "ProductPriceHistoryToOptionValues",
                column: "ProductPriceOptionValueId",
                principalSchema: "product",
                principalTable: "ProductPriceOptionValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceOptions_ProductCategories_ProductCategoryId",
                schema: "product",
                table: "ProductPriceOptions",
                column: "ProductCategoryId",
                principalSchema: "product",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceOptionValues_Products_ProductId",
                schema: "product",
                table: "ProductPriceOptionValues",
                column: "ProductId",
                principalSchema: "product",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
