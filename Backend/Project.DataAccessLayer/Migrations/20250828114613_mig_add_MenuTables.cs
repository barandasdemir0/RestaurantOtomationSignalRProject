using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_MenuTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuTables",
                columns: table => new
                {
                    MenuTableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTables", x => x.MenuTableID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuTables");
        }
    }
}
