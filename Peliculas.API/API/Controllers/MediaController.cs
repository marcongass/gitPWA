using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Flujo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase, IMediaController
    {
        private IMediaFlujo _mediaFlujo;
        private ILogger<MediaController> _logger;

        public MediaController(IMediaFlujo mediaFlujo, ILogger<MediaController> logger)
        {
            _mediaFlujo = mediaFlujo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListarMedia([FromQuery] bool esPelicula, [FromQuery] int genero)
        {
            var resultado = await _mediaFlujo.ListarMediaPorGenero(esPelicula, genero);

            return Ok(resultado);
        }
    }
}
