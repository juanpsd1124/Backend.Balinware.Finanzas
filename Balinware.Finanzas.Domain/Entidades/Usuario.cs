﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Domain.Entidades
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

    }
}
