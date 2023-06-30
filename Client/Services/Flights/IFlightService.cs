using FlightManagement.Shared;

namespace FlightManagement.Client.Services.Flights
{
    public interface IFlightService
    {
        Task GetFlights();
        Task<Flight> GetFlightBy(int id);
        Task CreateFlight(Flight flight);
        Task DeleteFlight(int id);
        Task UpdateFlight(int id, Flight flight);
        Task GetAirport();
        List<Flight> Flights { get; set; }
        List<Airport> Airports { get; set; }
    }
}
