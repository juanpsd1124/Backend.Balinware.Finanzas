using Balinware.Finanzas.Aplicacion.Interface.UseCases;
using Balinware.Finanzas.Application.UseCases.Registros;
using Microsoft.Extensions.DependencyInjection;


namespace Balinware.Finanzas.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IRegistrosApplication, RegistrosApplication>();

            return services;
        }



    }
}
