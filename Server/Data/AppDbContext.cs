using FlightManagement.Shared;

using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasData(
                new Airport
                {
                    Id = 1,
                    Name = "GUCY",
                    LatitudeDegree = 9,
                    LatitudeMinute = 34,
                    LatitudeSecond = 36,
                    LongitudeDegree = 13,
                    LongitudeMinute = 36,
                    LongitudeSecond = 43
                },
                new Airport
                {
                    Id = 2,
                    Name = "GOOY",
                    LatitudeDegree = 14,
                    LatitudeMinute = 44,
                    LatitudeSecond = 23,
                    LongitudeDegree = 17,
                    LongitudeMinute = 29,
                    LongitudeSecond = 25
                },
                new Airport
                {
                    Id = 3,
                    Name = "DIAP",
                    LatitudeDegree = 5,
                    LatitudeMinute = 15,
                    LatitudeSecond = 40,
                    LongitudeDegree = 3,
                    LongitudeMinute = 54,
                    LongitudeSecond = 34
                },
                new Airport
                {
                    Id = 4,
                    Name = "GABS",
                    LatitudeDegree = 12,
                    LatitudeMinute = 38,
                    LatitudeSecond = 0,
                    LongitudeDegree = 8,
                    LongitudeMinute = 1,
                    LongitudeSecond = 0
                },
                new Airport
                {
                    Id = 5,
                    Name = "GFLL",
                    LatitudeDegree = 8,
                    LatitudeMinute = 37,
                    LatitudeSecond = 0,
                    LongitudeDegree = 13,
                    LongitudeMinute = 12,
                    LongitudeSecond = 0
                },
                new Airport
                {
                    Id = 6,
                    Name = "GLRB",
                    LatitudeDegree = 6,
                    LatitudeMinute = 15,
                    LatitudeSecond = 10,
                    LongitudeDegree = 10,
                    LongitudeMinute = 21,
                    LongitudeSecond = 0
                },
                new Airport
                {
                    Id = 7,
                    Name = "GGOV",
                    LatitudeDegree = 11,
                    LatitudeMinute = 53,
                    LatitudeSecond = 41,
                    LongitudeDegree = 15,
                    LongitudeMinute = 39,
                    LongitudeSecond = 13
                });
        }
    }
}
