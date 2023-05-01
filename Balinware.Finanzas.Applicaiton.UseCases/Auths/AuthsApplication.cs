using AutoMapper;
using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Application.Interface.Persistence;
using Balinware.Finanzas.Application.Interface.UseCases;
using Balinware.Finanzas.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Application.UseCases.Auths
{
    public class AuthsApplication : IAuthsApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthsApplication(IUnitOfWork unitOfWork, IMapper imapper) 
        { 
            _unitOfWork = unitOfWork;
            _mapper = imapper;
        }

        public Response<AuthDTO> Authenticate(string username, string password) 
        { 
            var response = new Response<AuthDTO>();

            try 
            {
                var user = _unitOfWork.Auths.Authenticate(username, password);
                response.Data = _mapper.Map<AuthDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion Exitosa";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;



            return response;
        }    
    }
}
