using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddBlogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "ProductInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogProductInfo",
                columns: table => new
                {
                    BlogsId = table.Column<int>(type: "int", nullable: false),
                    ProductInfosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogProductInfo", x => new { x.BlogsId, x.ProductInfosId });
                    table.ForeignKey(
                        name: "FK_BlogProductInfo_Blog_BlogsId",
                        column: x => x.BlogsId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogProductInfo_ProductInfo_ProductInfosId",
                        column: x => x.ProductInfosId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogProductInfo_ProductInfosId",
                table: "BlogProductInfo",
                column: "ProductInfosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogProductInfo");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductInfo");
        }
    }
}
