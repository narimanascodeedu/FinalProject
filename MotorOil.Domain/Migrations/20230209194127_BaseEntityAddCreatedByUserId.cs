using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorOil.Domain.Migrations
{
    public partial class BaseEntityAddCreatedByUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Subscribes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductViscosities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductLiters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductCatalog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductApis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPostTagCloud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPostComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatedByUserId",
                table: "Tags",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DeletedUserId",
                table: "Tags",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_CreatedByUserId",
                table: "Subscribes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_DeletedUserId",
                table: "Subscribes",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductViscosities_CreatedByUserId",
                table: "ProductViscosities",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductViscosities_DeletedUserId",
                table: "ProductViscosities",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CreatedByUserId",
                table: "ProductTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_DeletedUserId",
                table: "ProductTypes",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedUserId",
                table: "Products",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLiters_CreatedByUserId",
                table: "ProductLiters",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLiters_DeletedUserId",
                table: "ProductLiters",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_CreatedByUserId",
                table: "ProductImages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_DeletedUserId",
                table: "ProductImages",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_CreatedByUserId",
                table: "ProductCatalog",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_DeletedUserId",
                table: "ProductCatalog",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductApis_CreatedByUserId",
                table: "ProductApis",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductApis_DeletedUserId",
                table: "ProductApis",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_CreatedByUserId",
                table: "Faqs",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_DeletedUserId",
                table: "Faqs",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPosts_CreatedByUserId",
                table: "ContactPosts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPosts_DeletedUserId",
                table: "ContactPosts",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeletedUserId",
                table: "Categories",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CreatedByUserId",
                table: "Brands",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_DeletedUserId",
                table: "Brands",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTagCloud_CreatedByUserId",
                table: "BlogPostTagCloud",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTagCloud_DeletedUserId",
                table: "BlogPostTagCloud",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CreatedByUserId",
                table: "BlogPosts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_DeletedUserId",
                table: "BlogPosts",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_CreatedByUserId",
                table: "BlogPostComments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_DeletedUserId",
                table: "BlogPostComments",
                column: "DeletedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_Users_CreatedByUserId",
                table: "BlogPostComments",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_Users_DeletedUserId",
                table: "BlogPostComments",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_CreatedByUserId",
                table: "BlogPosts",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_DeletedUserId",
                table: "BlogPosts",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTagCloud_Users_CreatedByUserId",
                table: "BlogPostTagCloud",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTagCloud_Users_DeletedUserId",
                table: "BlogPostTagCloud",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_CreatedByUserId",
                table: "Brands",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_DeletedUserId",
                table: "Brands",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_DeletedUserId",
                table: "Categories",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPosts_Users_CreatedByUserId",
                table: "ContactPosts",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPosts_Users_DeletedUserId",
                table: "ContactPosts",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_Users_CreatedByUserId",
                table: "Faqs",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_Users_DeletedUserId",
                table: "Faqs",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductApis_Users_CreatedByUserId",
                table: "ProductApis",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductApis_Users_DeletedUserId",
                table: "ProductApis",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_Users_CreatedByUserId",
                table: "ProductCatalog",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_Users_DeletedUserId",
                table: "ProductCatalog",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_CreatedByUserId",
                table: "ProductImages",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_DeletedUserId",
                table: "ProductImages",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLiters_Users_CreatedByUserId",
                table: "ProductLiters",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLiters_Users_DeletedUserId",
                table: "ProductLiters",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_DeletedUserId",
                table: "Products",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Users_CreatedByUserId",
                table: "ProductTypes",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Users_DeletedUserId",
                table: "ProductTypes",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductViscosities_Users_CreatedByUserId",
                table: "ProductViscosities",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductViscosities_Users_DeletedUserId",
                table: "ProductViscosities",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_Users_CreatedByUserId",
                table: "Subscribes",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_Users_DeletedUserId",
                table: "Subscribes",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_CreatedByUserId",
                table: "Tags",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_DeletedUserId",
                table: "Tags",
                column: "DeletedUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_Users_CreatedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_Users_DeletedUserId",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_DeletedUserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTagCloud_Users_CreatedByUserId",
                table: "BlogPostTagCloud");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTagCloud_Users_DeletedUserId",
                table: "BlogPostTagCloud");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_DeletedUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_DeletedUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPosts_Users_CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPosts_Users_DeletedUserId",
                table: "ContactPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_Users_CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_Users_DeletedUserId",
                table: "Faqs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductApis_Users_CreatedByUserId",
                table: "ProductApis");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductApis_Users_DeletedUserId",
                table: "ProductApis");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_Users_CreatedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_Users_DeletedUserId",
                table: "ProductCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_DeletedUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLiters_Users_CreatedByUserId",
                table: "ProductLiters");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLiters_Users_DeletedUserId",
                table: "ProductLiters");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_DeletedUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Users_CreatedByUserId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Users_DeletedUserId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductViscosities_Users_CreatedByUserId",
                table: "ProductViscosities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductViscosities_Users_DeletedUserId",
                table: "ProductViscosities");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_Users_CreatedByUserId",
                table: "Subscribes");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_Users_DeletedUserId",
                table: "Subscribes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_DeletedUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_DeletedUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Subscribes_CreatedByUserId",
                table: "Subscribes");

            migrationBuilder.DropIndex(
                name: "IX_Subscribes_DeletedUserId",
                table: "Subscribes");

            migrationBuilder.DropIndex(
                name: "IX_ProductViscosities_CreatedByUserId",
                table: "ProductViscosities");

            migrationBuilder.DropIndex(
                name: "IX_ProductViscosities_DeletedUserId",
                table: "ProductViscosities");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_CreatedByUserId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_DeletedUserId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeletedUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductLiters_CreatedByUserId",
                table: "ProductLiters");

            migrationBuilder.DropIndex(
                name: "IX_ProductLiters_DeletedUserId",
                table: "ProductLiters");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_DeletedUserId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalog_CreatedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalog_DeletedUserId",
                table: "ProductCatalog");

            migrationBuilder.DropIndex(
                name: "IX_ProductApis_CreatedByUserId",
                table: "ProductApis");

            migrationBuilder.DropIndex(
                name: "IX_ProductApis_DeletedUserId",
                table: "ProductApis");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_DeletedUserId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_ContactPosts_CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropIndex(
                name: "IX_ContactPosts_DeletedUserId",
                table: "ContactPosts");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DeletedUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_DeletedUserId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostTagCloud_CreatedByUserId",
                table: "BlogPostTagCloud");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostTagCloud_DeletedUserId",
                table: "BlogPostTagCloud");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_DeletedUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostComments_CreatedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostComments_DeletedUserId",
                table: "BlogPostComments");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductViscosities");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductLiters");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductCatalog");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductApis");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "BlogPostTagCloud");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "BlogPostComments");
        }
    }
}
