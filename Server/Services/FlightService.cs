using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Server.Services.Contracts;
using FlightManagement.Shared;

namespace FlightManagement.Server.Services
{
    public class FlightService : IFlightService
    {
        private readonly IRepositoryManager repository;

        public FlightService(IRepositoryManager repository)
        {
            this.repository = repository;
        }

        public Flight CreateFlight(Flight flight)
        {
            repository.Flight.CreateFlight(flight);
            repository.Save();
            return flight;
        }

        public void DeleteFlight(int id, bool trackchanges)
        {
            var entity = repository.Flight.GetFlightById(id, trackchanges);
            repository.Flight.DeleteFlight(entity);
            repository.Save();
        }

        public IEnumerable<Flight> GetAll(bool trackchanges)
        {
            return repository.Flight.GetFlights(trackchanges);
        }

        public Flight GetFlightBy(int id, bool trackchanges)
        {
            return repository.Flight.GetFlightById(id, trackchanges);
        }

        public void UpdateFlight(int id, Flight flight)
        {
            repository.Flight.UpdateFlight(flight);
            repository.Save();
        }
    }
}
