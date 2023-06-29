namespace FlightManagement.Server.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IFlightRepository Flight { get; }
        void Save();
    }
}
