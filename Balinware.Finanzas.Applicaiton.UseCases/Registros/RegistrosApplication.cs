using Balinware.Finanzas.Aplicacion.Interface.Persistence;
using Balinware.Finanzas.Aplicacion.Interface.UseCases;
using Balinware.Finanzas.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Balinware.Finanzas.Application.UseCases.Registros
{
    public class RegistrosApplication : IRegistrosApplication
    {
        private readonly IRegistrosRepository  _registrosRepository;

        public RegistrosApplication(IRegistrosRepository registrosRepository) { 
            _registrosRepository = registrosRepository;
        }    

        public Response<IEnumerable<RegistroDtoSalida>> GetAllMovimientos(int usuario, int tipo_movimiento)
        {
            var response = new Response<IEnumerable<RegistroDtoSalida>>();
            try
            {
                var registros = _registrosRepository.GetAllMovimientos(usuario, tipo_movimiento);
                response.Data = registros;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
