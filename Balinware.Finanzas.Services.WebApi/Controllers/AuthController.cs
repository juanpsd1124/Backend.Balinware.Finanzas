using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Application.Interface.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Balinware.Finanzas.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthsApplication _authApplication;

        public AuthController(IAuthsApplication authsApplication) 
        { 
            _authApplication = authsApplication;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthDTO authDTO) 
        {
            if (authDTO == null) 
            { 
                return BadRequest();
            }
            var response = _authApplication.Authenticate(authDTO.Username, authDTO.Password);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);


        }

    }
}
