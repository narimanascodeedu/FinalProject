using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorOil.Domain.Migrations
{
    public partial class ProductCatalogItemRelationAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "ProductCatalog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_ProductTypeId",
                table: "ProductCatalog",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductType_ProductTypeId",
                table: "ProductCatalog",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductType_ProductTypeId",
                table: "ProductCatalog");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalog_ProductTypeId",
                table: "ProductCatalog");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "ProductCatalog");
        }
    }
}
