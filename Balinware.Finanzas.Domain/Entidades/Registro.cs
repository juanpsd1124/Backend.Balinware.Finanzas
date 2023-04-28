using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Domain.Entidades
{
    public class Registro
    {

        public int Id_Registro { get; set; }
        public DateTime Fecha { get; set; }
        public int Username { get; set; }
        public float Valor { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public string Descripcion { get; set; }


        //public int Id_Registro { get; set; }
        //public DateTime Fecha { get; set; }
        //public string Username  { get; set; }
        //public float Valor { get; set; }
        //public string Tipo { get; set; }
        //public string Categoria { get; set; }
        //public string Descripcion { get; set; }

    }
}
