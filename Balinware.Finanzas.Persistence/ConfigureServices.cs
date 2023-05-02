using Balinware.Finanzas.Application.Interface.Persistence;
using Balinware.Finanzas.Persistence.Context;
using Balinware.Finanzas.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Balinware.Finanzas.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("MovimientosConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IRegistrosRepository, RegistrosRepository>();
            services.AddScoped<IAuthsRepository, AuthsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
        



    }
}
