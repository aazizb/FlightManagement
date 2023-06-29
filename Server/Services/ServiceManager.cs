using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Server.Services.Contracts;

namespace FlightManagement.Server.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IFlightService> flightService;
        public ServiceManager(IRepositoryManager manager)
        {
            flightService = new Lazy<IFlightService>(() => new
                FlightService(manager));
        }
        public IFlightService FlightService => flightService.Value;
    }
}
