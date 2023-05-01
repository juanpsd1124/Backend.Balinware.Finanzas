using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Transversal.Common;

namespace Balinware.Finanzas.Application.Interface.UseCases
{
    public interface IAuthsApplication
    {
        Response<AuthDTO> Authenticate(string username, string password);
    }


}
