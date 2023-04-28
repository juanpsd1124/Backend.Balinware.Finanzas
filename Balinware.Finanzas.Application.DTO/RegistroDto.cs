using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Application.DTO
{
    public class RegistroDto
    {
        public int Username { get; set; }
        public float Valor { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public string? Descripcion { get; set; }
    }
}
