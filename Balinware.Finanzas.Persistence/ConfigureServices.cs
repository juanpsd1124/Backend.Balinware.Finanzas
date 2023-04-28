using Balinware.Finanzas.Aplicacion.Interface.Persistence;
using Balinware.Finanzas.Persistence.Context;
using Balinware.Finanzas.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
