using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorOil.Domain.Migrations
{
    public partial class ProductCatalogItemRelationRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductTypes_ProductTypeId",
                table: "ProductCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalog_ProductTypeId",
                table: "ProductCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "ProductCatalog");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog",
                columns: new[] { "ProductId", "ProductViscosityId", "ProductLiterId", "ProductApiId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "ProductCatalog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog",
                columns: new[] { "ProductId", "ProductViscosityId", "ProductLiterId", "ProductApiId", "ProductTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_ProductTypeId",
                table: "ProductCatalog",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductTypes_ProductTypeId",
                table: "ProductCatalog",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
