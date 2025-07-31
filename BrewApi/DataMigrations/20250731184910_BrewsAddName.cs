using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrewApi.DataMigrations
{
    /// <inheritdoc />
    public partial class BrewsAddName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Brews");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Brews",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Brews");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Brews",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }
    }
}
