using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Shared;

using Moq;

namespace FlightManagement.UnitTests.MockData
{
    internal class MockIAirportRepository
    {
        public static Mock<IAirportRepository> GetMock()
        {
            var mock = new Mock<IAirportRepository>();

            var airports = new List<Airport>()
            {
                new Airport()
                {
                    Id = 1
                }
            };

            mock.Setup(m => m.GetAirports(false)).Returns(() => airports);

            return mock;
        }
    }
}
