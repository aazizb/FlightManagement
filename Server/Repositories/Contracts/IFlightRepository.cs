using FlightManagement.Shared;

namespace FlightManagement.Server.Repositories.Contracts
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetFlights(bool trackchanges);
        Flight GetFlightById(int id, bool trackchanges);
        void CreateFlight(Flight flight);
        void DeleteFlight(Flight flight);
        void UpdateFlight(Flight flight);
        IEnumerable<Flight> GetFlightAirports(bool trackchanges);
    }
}