using Dapper;
using Balinware.Finanzas.Aplicacion.Interface.Persistence;
using Balinware.Finanzas.Domain.Entidades;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Balinware.Finanzas.Persistence.Context;
using System.Data;
using System.Security.Principal;
using Newtonsoft.Json;

namespace Balinware.Finanzas.Persistence.Repositories
{
    public class RegistrosRepository : IRegistrosRepository
    {

        private readonly DapperContext _context;

        public RegistrosRepository(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<RegistroDtoSalida> GetAllMovimientos(int idUsuario, int tipoMovimiento)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "Movimientos_Usuario";
                var parameters = new DynamicParameters();
                parameters.Add("Id_Usuario", idUsuario);
                parameters.Add("Tipo_Movimiento", tipoMovimiento);
                var registros = connection.QuerySingle<string>(query, param: parameters, commandType: CommandType.StoredProcedure);
                var result = JsonConvert.DeserializeObject<IEnumerable<RegistroDtoSalida>>(registros);
                return result;
            }
        }
    }
}