using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Application.Interface.Persistence;
using Balinware.Finanzas.Domain.Entidades;
using Balinware.Finanzas.Persistence.Context;
using Dapper;
using Newtonsoft.Json;
using System.Data;

namespace Balinware.Finanzas.Persistence.Repositories
{
    public class RegistrosRepository : IRegistrosRepository
    {
        private readonly DapperContext _context;

        public RegistrosRepository(DapperContext context)
        {
            _context = context;
        }

        public bool Insert(Registro registro) 
        {
            using (var connection = _context.CreateConnection()) 
            {
                var query = "Insertar_Registro";
                var parameters = new DynamicParameters();
                parameters.Add("Id_Usuario", registro.Username);
                parameters.Add("Fecha", registro.Fecha);
                parameters.Add("Valor", registro.Valor);
                parameters.Add("Tipo", registro.Tipo);
                parameters.Add("Categoria", registro.Categoria);
                parameters.Add("Descripcion", registro.Descripcion);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
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