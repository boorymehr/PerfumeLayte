using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeLayte.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewDatassdw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeProduct_Product_ProductId",
                table: "LikeProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "LikeProduct",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_LikeProduct_ProductId",
                table: "LikeProduct",
                newName: "IX_LikeProduct_Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeProduct_Product_Productid",
                table: "LikeProduct",
                column: "Productid",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeProduct_Product_Productid",
                table: "LikeProduct");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "LikeProduct",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeProduct_Productid",
                table: "LikeProduct",
                newName: "IX_LikeProduct_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeProduct_Product_ProductId",
                table: "LikeProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
