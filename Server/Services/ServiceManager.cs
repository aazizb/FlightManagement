using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Server.Services.Contracts;

namespace FlightManagement.Server.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IFlightService> flightService;
        private readonly Lazy<IAirportService> airportService;
        public ServiceManager(IRepositoryManager manager)
        {
            flightService = new Lazy<IFlightService>(() => new
                FlightService(manager));
            airportService = new Lazy<IAirportService>(() => new
                AirportService(manager));
        }
        public IFlightService FlightService => flightService.Value;
        public IAirportService AirportService => airportService.Value;

    }
}
