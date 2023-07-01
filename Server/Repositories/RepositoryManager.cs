using FlightManagement.Server.Data;
using FlightManagement.Server.Repositories.Contracts;

namespace FlightManagement.Server.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext context;
        private readonly Lazy<IFlightRepository> flightRepository;
        private readonly Lazy<IAirportRepository> airportRepository;
        public RepositoryManager(AppDbContext context)
        {
            this.context = context;
            flightRepository = new Lazy<IFlightRepository>(() => new
                FlightRepository(context));
            airportRepository = new Lazy<IAirportRepository>(() => new
                AirportRepository(context));
        }
        public IFlightRepository Flight => flightRepository.Value;

        public IAirportRepository Airport => airportRepository.Value;

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
