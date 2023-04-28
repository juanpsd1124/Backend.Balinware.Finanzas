using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Domain.Entidades;

namespace Balinware.Finanzas.Application.Interface.Persistence
{
    public interface IRegistrosRepository
    {
        public bool Insert(Registro registro);
        public IEnumerable<RegistroDtoSalida> GetAllMovimientos(int usuario, int tipo_movimiento);

    }
}
