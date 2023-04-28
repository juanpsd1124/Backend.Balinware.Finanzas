﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Domain.Entidades
{
    public class Registro
    {
        public int Username { get; set; }
        public float Valor { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public string? Descripcion { get; set; }
        public string Fecha { get; set; }

        public Registro()
        {
            this.Fecha = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
