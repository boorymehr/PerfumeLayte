using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeLayte.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.CreateTable(
                name: "LikeProduct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeProduct", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeProduct");

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    isMain = table.Column<bool>(type: "bit", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.ID);
                });
        }
    }
}
