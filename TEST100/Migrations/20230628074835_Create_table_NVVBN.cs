using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST100.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_NVVBN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NVVBN",
                columns: table => new
                {
                    Quequan = table.Column<string>(type: "TEXT", nullable: false),
                    Ten = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVVBN", x => x.Quequan);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NVVBN");
        }
    }
}
