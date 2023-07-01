using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Server.Services.Contracts;
using FlightManagement.Shared;

namespace FlightManagement.Server.Services
{
    public class AirportService : IAirportService
    {
        private readonly IRepositoryManager repository;

        public AirportService(IRepositoryManager repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Airport> GetAll(bool trackchanges)
        {
            return repository.Airport.GetAirports(trackchanges);
        }
    }
}
