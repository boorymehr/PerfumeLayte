using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeLayte.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewDatassdwewqqwq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeProduct_Product_Productid",
                table: "LikeProduct");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "LikeProduct",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_LikeProduct_Productid",
                table: "LikeProduct",
                newName: "IX_LikeProduct_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeProduct_Product_ProductID",
                table: "LikeProduct",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeProduct_Product_ProductID",
                table: "LikeProduct");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "LikeProduct",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_LikeProduct_ProductID",
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
    }
}
