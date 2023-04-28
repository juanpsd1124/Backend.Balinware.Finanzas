using Balinware.Finanzas.Aplicacion.Interface.Persistence;
using Balinware.Finanzas.Aplicacion.Interface.UseCases;
using Balinware.Finanzas.Applicaiton.UseCases.Registros;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Applicaiton.UseCases
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
