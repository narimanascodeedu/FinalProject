using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorOil.Domain.Migrations
{
    public partial class ProductViscosities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_Viscosities_ProductViscosityId",
                table: "ProductCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Viscosities",
                table: "Viscosities");

            migrationBuilder.RenameTable(
                name: "Viscosities",
                newName: "ProductViscosities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductViscosities",
                table: "ProductViscosities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductViscosities_ProductViscosityId",
                table: "ProductCatalog",
                column: "ProductViscosityId",
                principalTable: "ProductViscosities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductViscosities_ProductViscosityId",
                table: "ProductCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductViscosities",
                table: "ProductViscosities");

            migrationBuilder.RenameTable(
                name: "ProductViscosities",
                newName: "Viscosities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Viscosities",
                table: "Viscosities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_Viscosities_ProductViscosityId",
                table: "ProductCatalog",
                column: "ProductViscosityId",
                principalTable: "Viscosities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
