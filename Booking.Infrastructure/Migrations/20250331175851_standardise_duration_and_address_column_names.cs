using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class standardise_duration_and_address_column_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration_Start",
                table: "Booking",
                newName: "DurationStart");

            migrationBuilder.RenameColumn(
                name: "Duration_End",
                table: "Booking",
                newName: "DurationEnd");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "Apartment",
                newName: "AddressZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Apartment",
                newName: "AddressStreet");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Apartment",
                newName: "AddressState");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Apartment",
                newName: "AddressCountry");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Apartment",
                newName: "AddressCity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationStart",
                table: "Booking",
                newName: "Duration_Start");

            migrationBuilder.RenameColumn(
                name: "DurationEnd",
                table: "Booking",
                newName: "Duration_End");

            migrationBuilder.RenameColumn(
                name: "AddressZipCode",
                table: "Apartment",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "AddressStreet",
                table: "Apartment",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "AddressState",
                table: "Apartment",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "AddressCountry",
                table: "Apartment",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "AddressCity",
                table: "Apartment",
                newName: "Address_City");
        }
    }
}
