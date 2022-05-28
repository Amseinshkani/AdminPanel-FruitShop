using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitShop6.Migrations
{
    public partial class factorp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Factors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    upimg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requestedweight = table.Column<int>(type: "int", nullable: false),
                    totalweight = table.Column<int>(type: "int", nullable: false),
                    sum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Factors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Factors");
        }
    }
}
