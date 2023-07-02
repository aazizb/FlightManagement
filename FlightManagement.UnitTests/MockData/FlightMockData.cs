using FlightManagement.Shared;

namespace FlightManagement.UnitTests.MockData
{
    public class FlightMockData
    {
        public static List<Airport> GetAirports()
        {
            return new List<Airport>
            {
                new Airport {Id = 1, Name = "GUCY"},
                new Airport {Id = 2, Name = "GOOY"},
                new Airport {Id = 3, Name = "GABS"}
            };
        }
        public static List<Flight> GetFlights()
        {
            return new List<Flight>
            {
                new Flight
                {
                    Id = 1,
                    Name = "ZCZC",
                    DepartureId = 1,
                    DestinationId = 2,
                    Distance = 123
                },
                new Flight
                {
                    Id = 1,
                    Name = "ZCZC",
                    DepartureId = 1,
                    DestinationId = 2,
                    Distance = 123
                }
            };
        }

    }
}
