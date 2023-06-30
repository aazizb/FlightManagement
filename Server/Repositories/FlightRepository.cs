using FlightManagement.Server.Data;
using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Shared;

namespace FlightManagement.Server.Repositories
{
    public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        public FlightRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateFlight(Flight flight)
        {
            Create(flight);
        }

        public void DeleteFlight(Flight flight)
        {
            Delete(flight);
        }

        public Flight GetFlightById(int id, bool trackchanges)
        {
            return FindBy(o => o.Id.Equals(id), trackchanges)
                .SingleOrDefault();
        }

        public IEnumerable<Flight> GetFlights(bool trackchanges)
        {
            return FindAll(trackchanges).OrderBy(o => o.Id)
                .ToList();
        }

        public void UpdateFlight(Flight flight)
        {
            Update(flight);
        }
    }
}
