namespace FlightManagement.Server.Services.Contracts
{
    public interface IServiceManager
    {
        IFlightService FlightService { get; }
    }
}
