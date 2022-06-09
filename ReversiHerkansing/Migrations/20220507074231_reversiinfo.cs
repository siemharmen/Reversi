using Microsoft.EntityFrameworkCore.Migrations;

namespace ReversiHerkansing.Migrations
{
    public partial class reversiinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReversiInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beurt = table.Column<int>(type: "int", nullable: false),
                    SpelId = table.Column<int>(type: "int", nullable: false),
                    Zwart = table.Column<int>(type: "int", nullable: false),
                    Wit = table.Column<int>(type: "int", nullable: false),
                    addZwart = table.Column<int>(type: "int", nullable: false),
                    addWit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReversiInfo", x => x.Id);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "ReversiInfo");

            migrationBuilder.DropTable(
                name: "Spellen");
        }
    }
}
