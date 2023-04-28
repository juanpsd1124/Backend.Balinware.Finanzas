using Balinware.Finanzas.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Aplicacion.Interface.UseCases
{
    public interface IRegistrosApplication
    {
        Response<IEnumerable<RegistroDtoSalida>> GetAllMovimientos(int usuario, int tipo_movimiento);
    }
}
