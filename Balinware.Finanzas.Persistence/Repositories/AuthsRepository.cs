using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Application.Interface.Persistence;
using Balinware.Finanzas.Domain.Entidades;
using Balinware.Finanzas.Persistence.Context;
using Dapper;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Persistence.Repositories
{
    public class AuthsRepository : IAuthsRepository
    {
        private readonly DapperContext _context;
        public AuthsRepository(DapperContext context) 
        { 
            _context = context;
        }

        public UserAuth Authenticate(string username, string password)
        {
            using (var connection = _context.CreateConnection()) 
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("Username", username);
                parameters.Add("Password", password);
                var registros = connection.QuerySingle<string>(query, param: parameters, commandType: CommandType.StoredProcedure);
                
                var user = JsonConvert.DeserializeObject<UserAuth>(registros);
                return user;
            }
        }
    }
}
