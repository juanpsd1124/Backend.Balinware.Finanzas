using Balinware.Finanzas.Application.DTO;
using Balinware.Finanzas.Application.Interface.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Balinware.Finanzas.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : Controller
    {
        private readonly IRegistrosApplication  _registrosApplication;
        public RegistrosController(IRegistrosApplication registrosApplication) 
        {
            _registrosApplication = registrosApplication;
        }

        #region "Metodos Sincronos"

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] RegistroDto registroDto)
        {
            if (registroDto == null)
                return BadRequest();
            var response = _registrosApplication.Insert(registroDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll/{usuarioId}")]
        public IActionResult GetAll(int usuarioId) 
        {
            var response = _registrosApplication.GetAllMovimientos(usuarioId , 1);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        #endregion

     


    }
}
