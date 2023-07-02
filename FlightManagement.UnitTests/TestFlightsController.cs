using FlightManagement.Server.Services;
using FlightManagement.Shared;
using FlightManagement.UnitTests.MockData;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.UnitTests
{
    public class TestFlightsController
    {
        [Fact]
        public void WhenGettingAllFlight_ThenAllFlightsReturn()
        {
            var repositoryManagerMock = MockIRepositoryManager.GetMock();

            var flightsService = new FlightService(repositoryManagerMock.Object);

            var result = flightsService.GetFlightAirports(false) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<Flight>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<Flight>);


        }
    }
}