using FlightManagement.Server.Repositories.Contracts;

using Moq;

namespace FlightManagement.UnitTests.MockData
{
    internal class MockIRepositoryManager
    {
        public static Mock<IRepositoryManager> GetMock()
        {
            var mock = new Mock<IRepositoryManager>();
            var flightRepoMock = MockIFlightRepository.GetMock();
            var airportRepoMock = MockIAirportRepository.GetMock();

            mock.Setup(m => m.Flight).Returns(() => flightRepoMock.Object);
            mock.Setup(m => m.Airport).Returns(() => airportRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}