using FlightManagement.Client.Services.Flights;

namespace FlightManagement.Client.Extensions
{
    public static class IServiceCollectionExtensions
    {
        private static void ConfigureFlightService(this IServiceCollection services)
        {
            services.AddScoped<IFlightService, FlightService>();
        }
        public static void AddClientSideServices(this IServiceCollection services)
        {
            services.ConfigureFlightService();
        }
    }
}
