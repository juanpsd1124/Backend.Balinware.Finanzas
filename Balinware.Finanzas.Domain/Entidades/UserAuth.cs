using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Domain.Entidades
{
    public class UserAuth
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public string Token { get; set; }
    }
}
