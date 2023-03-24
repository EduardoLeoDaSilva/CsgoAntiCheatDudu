using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsgoAntiCheatDudu.Migrations
{
    /// <inheritdoc />
    public partial class ServerStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServerStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerStatus");
        }
    }
}
