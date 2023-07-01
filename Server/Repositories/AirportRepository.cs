using FlightManagement.Server.Data;
using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Shared;

namespace FlightManagement.Server.Repositories
{
    public class AirportRepository : RepositoryBase<Airport>, IAirportRepository
    {

        public AirportRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Airport> GetAirports(bool trackchanges)
        {
            return FindAll(trackchanges).OrderBy(o => o.Id)
                .ToList();
        }
    }
}
