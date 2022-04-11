using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsgoAntiCheatDudu.Migrations
{
    /// <inheritdoc />
    public partial class coluna_LastPhotoTake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastPhotoTaken",
                table: "players",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPhotoTaken",
                table: "players");
        }
    }
}
