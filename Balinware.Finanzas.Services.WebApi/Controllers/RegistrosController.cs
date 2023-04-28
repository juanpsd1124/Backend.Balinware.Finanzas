using Balinware.Finanzas.Aplicacion.Interface.UseCases;
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
