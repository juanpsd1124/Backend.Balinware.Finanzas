using Balinware.Finanzas.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Balinware.Finanzas.Aplicacion.Interface.UseCases
{
    public interface IRegistrosApplication
    {
        Response<IEnumerable<RegistroDtoSalida>> GetAllMovimientos(int usuario, int tipo_movimiento);
    }
}
