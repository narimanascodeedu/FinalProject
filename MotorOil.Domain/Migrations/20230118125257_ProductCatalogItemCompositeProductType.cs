using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorOil.Domain.Migrations
{
    public partial class ProductCatalogItemCompositeProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog",
                columns: new[] { "ProductId", "ProductViscosityId", "ProductLiterId", "ProductApiId", "ProductTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog",
                columns: new[] { "ProductId", "ProductViscosityId", "ProductLiterId", "ProductApiId" });
        }
    }
}
