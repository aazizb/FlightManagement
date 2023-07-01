using FlightManagement.Server.LoggerService;
using FlightManagement.Server.Repositories;
using FlightManagement.Server.Repositories.Contracts;
using FlightManagement.Server.Services;
using FlightManagement.Server.Services.Contracts;

namespace FlightManagement.Server.Extensions
{
    public static class IServiceCollectionExtensions
    {
        private static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        private static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
        private static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void AddServerSideServices(this IServiceCollection services)
        {
            services.ConfigureLoggerService();
            services.ConfigureRepositoryManager();
            services.ConfigureServiceManager();
        }
    }
}
