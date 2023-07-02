using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Shared;

using Moq;

namespace FlightManagement.UnitTests.MockData
{
    internal class MockIFlightRepository
    {
        public static Mock<IFlightRepository> GetMock()
        {
            var mock = new Mock<IFlightRepository>();

            var flights = new List<Flight>()
            {
                new Flight()
                {
                    Id = 1,
                    Name = "ZCZC",
                    DepartureId = 1,
                    Departure = new Airport{Id = 1, Name ="GUCY"},
                    DestinationId = 2,
                    Destination = new Airport{Id=3, Name="GOOY"},
                    Distance = 333
                }
            };

            mock.Setup(m => m.GetFlights(false)).Returns(() => flights);


            //mock.Setup(m => m.GetFlightById(It.IsAny<int>(), false))
            //    .Returns((int id) => flights.FirstOrDefault(o => o.Id == id));
            mock.Setup(m => m.GetFlightById(It.IsNotNull<int>())).Returns((int id) => flights.FirstOrDefault(o => o.Id == id));

            mock.Setup(m => m.GetFlightAirports(false)).Returns(() => flights);

            mock.Setup(m => m.CreateFlight(It.IsAny<Flight>()))
                .Callback(() => { return; });

            mock.Setup(m => m.UpdateFlight(It.IsAny<Flight>()))
               .Callback(() => { return; });

            mock.Setup(m => m.DeleteFlight(It.IsAny<Flight>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
