using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class apartmentversionfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Apartment");

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Apartment",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[] { }); // required for non-null
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Apartment");

            migrationBuilder.AddColumn<uint>(
                name: "Version",
                table: "Apartment",
                type: "int", // or "bigint" if you were using long
                nullable: false,
                defaultValue: 0u);
        }
    }
}
