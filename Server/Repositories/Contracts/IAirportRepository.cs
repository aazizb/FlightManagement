using FlightManagement.Shared;

namespace FlightManagement.Server.Repositories.Contracts
{
    public interface IAirportRepository
    {
        IEnumerable<Airport> GetAirports(bool trackchanges);
    }
}