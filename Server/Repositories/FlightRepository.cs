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
    }
}
