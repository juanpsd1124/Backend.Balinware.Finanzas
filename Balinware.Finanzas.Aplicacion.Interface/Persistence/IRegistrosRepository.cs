
using Balinware.Finanzas.Persistence;

namespace Balinware.Finanzas.Aplicacion.Interface.Persistence
{
    public interface IRegistrosRepository 
    {

        public IEnumerable<RegistroDtoSalida> GetAllMovimientos(int usuario, int tipo_movimiento);

    }
}
