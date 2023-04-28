using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Domain.Entidades;
using Balinware.Finanzas.Transversal.Common;

namespace Balinware.Finanzas.Application.Interface.UseCases
{
    public interface IRegistrosApplication
    {
        Response<Registro> Insert(RegistroDto registroDto);

        Response<IEnumerable<RegistroDtoSalida>> GetAllMovimientos(int usuario, int tipo_movimiento);
    }
}
