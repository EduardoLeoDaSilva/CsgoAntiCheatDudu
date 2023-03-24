using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsgoAntiCheatDudu.Migrations
{
    /// <inheritdoc />
    public partial class dropBoxToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DropboxTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expiration = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropboxTokens", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DropboxTokens");
        }
    }
}
