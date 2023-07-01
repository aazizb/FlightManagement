using FlightManagement.Server.Data;
using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Shared;

using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Server.Repositories
{
    public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        private readonly AppDbContext context;

        public FlightRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public void CreateFlight(Flight flight)
        {
            Create(flight);
        }

        public void DeleteFlight(Flight flight)
        {
            Delete(flight);
        }

        public IEnumerable<Flight> GetFlightAirports(bool trackchanges)
        {
            return !trackchanges ?
                context.Flights.Include(o => o.Departure).Include(o => o.Destination).AsNoTracking() :
                context.Flights.Include(o => o.Departure).Include(o => o.Destination);
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
