using Balinware.Finanzas.Domain.Entidades;
using Balinware.Finanzas.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Aplicacion.Interface.Persistence
{
    public interface IRegistrosRepository 
    {

        public IEnumerable<RegistroDtoSalida> GetAllMovimientos(int usuario, int tipo_movimiento);

    }
}
