using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeLayte.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "LikeProduct");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "LikeProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "LikeProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LikeProduct_ProductId",
                table: "LikeProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeProduct_UserID",
                table: "LikeProduct",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeProduct_Product_ProductId",
                table: "LikeProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeProduct_User_UserID",
                table: "LikeProduct",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeProduct_Product_ProductId",
                table: "LikeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeProduct_User_UserID",
                table: "LikeProduct");

            migrationBuilder.DropIndex(
                name: "IX_LikeProduct_ProductId",
                table: "LikeProduct");

            migrationBuilder.DropIndex(
                name: "IX_LikeProduct_UserID",
                table: "LikeProduct");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "LikeProduct");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LikeProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "LikeProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
