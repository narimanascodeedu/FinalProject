using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorOil.Domain.Migrations
{
    public partial class CompositePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCatalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductViscosityId = table.Column<int>(type: "int", nullable: false),
                    ProductLiterId = table.Column<int>(type: "int", nullable: false),
                    ProductApiId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatalog", x => new { x.ProductId, x.ProductViscosityId, x.ProductLiterId, x.ProductApiId });
                    table.ForeignKey(
                        name: "FK_ProductCatalog_ProductApis_ProductApiId",
                        column: x => x.ProductApiId,
                        principalTable: "ProductApis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_ProductLiters_ProductLiterId",
                        column: x => x.ProductLiterId,
                        principalTable: "ProductLiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Viscosities_ProductViscosityId",
                        column: x => x.ProductViscosityId,
                        principalTable: "Viscosities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_ProductApiId",
                table: "ProductCatalog",
                column: "ProductApiId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_ProductLiterId",
                table: "ProductCatalog",
                column: "ProductLiterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_ProductViscosityId",
                table: "ProductCatalog",
                column: "ProductViscosityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCatalog");
        }
    }
}
