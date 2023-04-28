using AutoMapper;
using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Application.Interface.Persistence;
using Balinware.Finanzas.Application.Interface.UseCases;
using Balinware.Finanzas.Domain.Entidades;
using Balinware.Finanzas.Transversal.Common;

namespace Balinware.Finanzas.Application.UseCases.Registros
{
    public class RegistrosApplication : IRegistrosApplication
    {
        private readonly IRegistrosRepository  _registrosRepository;
        private readonly IMapper _mapper;

        public RegistrosApplication(IRegistrosRepository registrosRepository, IMapper mapper) { 
            _registrosRepository = registrosRepository;
            _mapper = mapper;
        }

        public Response<Registro> Insert(RegistroDto registroDto)
        {
            var response = new Response<Registro>();
            try
            {
                var registro = _mapper.Map<Registro>(registroDto);
                var isInsert = _registrosRepository.Insert(registro);
                if (isInsert)
                {
                    response.Data = registro;
                    response.IsSuccess = true;
                    response.Message = "Registro Creado";
                }
            }

            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
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
