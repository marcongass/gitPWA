using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase, IGeneroController
    {
        private IGeneroFlujo _generoFlujo;
        private ILogger<GeneroController> _logger;

        public GeneroController(IGeneroFlujo generoFlujo, ILogger<GeneroController> logger)
        {
            _generoFlujo = generoFlujo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerGeneros([FromQuery] string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo) || (tipo != "movie" && tipo != "tv"))
                return BadRequest("Tipo debe ser 'movie' o 'tv'.");

            var generos = await _generoFlujo.ObtenerGeneros(tipo);
            return Ok(generos);
        }
    }
}