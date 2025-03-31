using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class booking_table_rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_Apartment_ApartmentId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_User_UserId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_bookings_BookingId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookings",
                table: "bookings");

            migrationBuilder.RenameTable(
                name: "bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_UserId",
                table: "Booking",
                newName: "IX_Booking_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_ApartmentId",
                table: "Booking",
                newName: "IX_Booking_ApartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Apartment_ApartmentId",
                table: "Booking",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_UserId",
                table: "Booking",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Booking_BookingId",
                table: "Review",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Apartment_ApartmentId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_UserId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Booking_BookingId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserId",
                table: "bookings",
                newName: "IX_bookings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ApartmentId",
                table: "bookings",
                newName: "IX_bookings_ApartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookings",
                table: "bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_Apartment_ApartmentId",
                table: "bookings",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_User_UserId",
                table: "bookings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_bookings_BookingId",
                table: "Review",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
