using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Application.DTO
{
    public class AuthDTO
    {
        public string? Id_Usuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Token { get; set; }
    }
}
