using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST100.Migrations
{
    /// <inheritdoc />
    public partial class Create_ForeignKey_table_NVVHN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NVVHN",
                columns: table => new
                {
                    Quequan = table.Column<string>(type: "TEXT", nullable: false),
                    NGo = table.Column<string>(type: "TEXT", nullable: false),
                    Sonha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVVHN", x => x.Quequan);
                    table.ForeignKey(
                        name: "FK_NVVHN_NVVBN_Quequan",
                        column: x => x.Quequan,
                        principalTable: "NVVBN",
                        principalColumn: "Quequan",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NVVHN");
        }
    }
}
