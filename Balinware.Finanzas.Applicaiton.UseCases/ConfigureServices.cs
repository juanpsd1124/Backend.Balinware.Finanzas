using Balinware.Finanzas.Application.Interface.UseCases;
using Balinware.Finanzas.Application.UseCases.Registros;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Balinware.Finanzas.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IRegistrosApplication, RegistrosApplication>();

            return services;
        }



    }
}
