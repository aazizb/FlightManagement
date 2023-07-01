using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatitudeDegree = table.Column<int>(type: "int", nullable: false),
                    LatitudeMinute = table.Column<int>(type: "int", nullable: false),
                    LatitudeSecond = table.Column<int>(type: "int", nullable: false),
                    LongitudeDegree = table.Column<int>(type: "int", nullable: false),
                    LongitudeMinute = table.Column<int>(type: "int", nullable: false),
                    LongitudeSecond = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    //table.ForeignKey(
                    //    name: "FK_Flights_Airports_DestinationId",
                    //    column: x => x.DestinationId,
                    //    principalTable: "Airports",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "LatitudeDegree", "LatitudeMinute", "LatitudeSecond", "LongitudeDegree", "LongitudeMinute", "LongitudeSecond", "Name" },
                values: new object[,]
                {
                    { 1, 9, 34, 36, 13, 36, 43, "GUCY" },
                    { 2, 14, 44, 23, 17, 29, 25, "GOOY" },
                    { 3, 5, 15, 40, 3, 54, 34, "DIAP" },
                    { 4, 12, 38, 0, 8, 1, 0, "GABS" },
                    { 5, 8, 37, 0, 13, 12, 0, "GFLL" },
                    { 6, 6, 15, 10, 10, 21, 0, "GLRB" },
                    { 7, 11, 53, 41, 15, 39, 13, "GGOV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DestinationId",
                table: "Flights",
                column: "DestinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
