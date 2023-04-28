using Balinware.Finanzas.Application.Interface.Persistence;
using Balinware.Finanzas.Persistence.Context;
using Balinware.Finanzas.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Balinware.Finanzas.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>(); 
            services.AddScoped<IRegistrosRepository, RegistrosRepository>();

            return services;
        }
        



    }
}
