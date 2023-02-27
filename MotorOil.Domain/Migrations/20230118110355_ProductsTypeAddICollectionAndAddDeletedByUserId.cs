using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorOil.Domain.Migrations
{
    public partial class ProductsTypeAddICollectionAndAddDeletedByUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "Subscribes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "ProductViscosities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockKeepingUnit",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "ProductLiters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "ProductCatalog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "ProductApis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "BlogPostTagCloud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "BlogPostComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "ProductViscosities");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockKeepingUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "ProductLiters");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "ProductCatalog");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "ProductApis");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "BlogPostTagCloud");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "BlogPostComments");
        }
    }
}
