using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class standardise_column_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice_Currency",
                table: "Booking",
                newName: "TotalPriceCurrency");

            migrationBuilder.RenameColumn(
                name: "TotalPrice_Amount",
                table: "Booking",
                newName: "TotalPriceAmount");

            migrationBuilder.RenameColumn(
                name: "PriceForPeriod_Currency",
                table: "Booking",
                newName: "PriceForPeriodCurrency");

            migrationBuilder.RenameColumn(
                name: "PriceForPeriod_Amount",
                table: "Booking",
                newName: "PriceForPeriodAmount");

            migrationBuilder.RenameColumn(
                name: "CleaningFee_Currency",
                table: "Booking",
                newName: "CleaningFeeCurrency");

            migrationBuilder.RenameColumn(
                name: "CleaningFee_Amount",
                table: "Booking",
                newName: "CleaningFeeAmount");

            migrationBuilder.RenameColumn(
                name: "AmenitiesUpCharge_Currency",
                table: "Booking",
                newName: "AmenitiesUpChargeCurrency");

            migrationBuilder.RenameColumn(
                name: "AmenitiesUpCharge_Amount",
                table: "Booking",
                newName: "AmenitiesUpChargeAmount");

            migrationBuilder.RenameColumn(
                name: "Price_Currency",
                table: "Apartment",
                newName: "PriceCurrency");

            migrationBuilder.RenameColumn(
                name: "Price_Amount",
                table: "Apartment",
                newName: "PriceAmount");

            migrationBuilder.RenameColumn(
                name: "CleaningFee_Currency",
                table: "Apartment",
                newName: "CleaningFeeCurrency");

            migrationBuilder.RenameColumn(
                name: "CleaningFee_Amount",
                table: "Apartment",
                newName: "CleaningFeeAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPriceCurrency",
                table: "Booking",
                newName: "TotalPrice_Currency");

            migrationBuilder.RenameColumn(
                name: "TotalPriceAmount",
                table: "Booking",
                newName: "TotalPrice_Amount");

            migrationBuilder.RenameColumn(
                name: "PriceForPeriodCurrency",
                table: "Booking",
                newName: "PriceForPeriod_Currency");

            migrationBuilder.RenameColumn(
                name: "PriceForPeriodAmount",
                table: "Booking",
                newName: "PriceForPeriod_Amount");

            migrationBuilder.RenameColumn(
                name: "CleaningFeeCurrency",
                table: "Booking",
                newName: "CleaningFee_Currency");

            migrationBuilder.RenameColumn(
                name: "CleaningFeeAmount",
                table: "Booking",
                newName: "CleaningFee_Amount");

            migrationBuilder.RenameColumn(
                name: "AmenitiesUpChargeCurrency",
                table: "Booking",
                newName: "AmenitiesUpCharge_Currency");

            migrationBuilder.RenameColumn(
                name: "AmenitiesUpChargeAmount",
                table: "Booking",
                newName: "AmenitiesUpCharge_Amount");

            migrationBuilder.RenameColumn(
                name: "PriceCurrency",
                table: "Apartment",
                newName: "Price_Currency");

            migrationBuilder.RenameColumn(
                name: "PriceAmount",
                table: "Apartment",
                newName: "Price_Amount");

            migrationBuilder.RenameColumn(
                name: "CleaningFeeCurrency",
                table: "Apartment",
                newName: "CleaningFee_Currency");

            migrationBuilder.RenameColumn(
                name: "CleaningFeeAmount",
                table: "Apartment",
                newName: "CleaningFee_Amount");
        }
    }
}
