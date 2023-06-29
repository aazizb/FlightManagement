using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Server.Services.Contracts;

namespace FlightManagement.Server.Services
{
    public class FlightService : IFlightService
    {
        private readonly IRepositoryManager repository;

        public FlightService(IRepositoryManager repository)
        {
            this.repository = repository;
        }
    }
}
