using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_update_fligts_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "AirportId",
                table: "Flights",
                newName: "DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                newName: "IX_Flights_DestinationId");

            migrationBuilder.AddColumn<int>(
                name: "DepartureAirportId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationAirportId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights",
                column: "DepartureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DepartureId",
                table: "Flights",
                column: "DepartureId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DestinationId",
                table: "Flights",
                column: "DestinationId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DestinationId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DestinationAirportId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "Flights",
                newName: "AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_DestinationId",
                table: "Flights",
                newName: "IX_Flights_AirportId");

            migrationBuilder.AddColumn<string>(
                name: "Departure",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_AirportId",
                table: "Flights",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
