using FlightManagement.Shared;

namespace FlightManagement.Server.Services.Contracts
{
    public interface IAirportService
    {
        IEnumerable<Airport> GetAll(bool trackchanges);
    }
}
