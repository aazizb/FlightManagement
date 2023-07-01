namespace FlightManagement.Server.Services.Contracts
{
    public interface IServiceManager
    {
        IFlightService FlightService { get; }
        IAirportService AirportService { get; }
    }
}
