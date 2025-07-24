using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.API;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaVisualizacionController : ControllerBase, IListaVisualizacionController
    {
        private IListaVisualizacionFlujo _listaVisualizacionFlujo;
        private ILogger<ListaVisualizacionController> _logger;

        public ListaVisualizacionController(IListaVisualizacionFlujo listaVisualizacionFlujo, ILogger<ListaVisualizacionController> logger)
        {
            _listaVisualizacionFlujo = listaVisualizacionFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMediaLista([FromBody] ListaVisualizacion mediaListaVisualizacion)
        {
            Guid resultado = await _listaVisualizacionFlujo.AgregarMediaLista(mediaListaVisualizacion);

            if (resultado == Guid.Empty)
            {
                _logger.LogError("Error al agregar la media lista.");
                return BadRequest("No se pudo agregar la media lista.");
            }

            return CreatedAtAction(nameof(ObtenerMediaLista), new { idMediaLista = resultado }, null);
        }

        [HttpPut]
        public async Task<IActionResult> EditarMediaLista([FromQuery] Guid idMediaLista, [FromBody] ListaVisualizacion mediaListaVisualizacion)
        {
            Guid resultado = await _listaVisualizacionFlujo.EditarMediaLista(idMediaLista, mediaListaVisualizacion);

            if (resultado == Guid.Empty)
            {
                _logger.LogError("Error al editar la media lista.");
                return BadRequest("No se pudo editar la media lista.");
            }

            return Ok(resultado);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarMediaLista([FromQuery] Guid idMediaLista)
        {
            Guid resultado = await _listaVisualizacionFlujo.EliminarMediaLista(idMediaLista);

            if (resultado == Guid.Empty)
            {
                _logger.LogError("Error al eliminar la media lista.");
                return BadRequest("No se pudo eliminar la media lista.");
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerListaCompletaPorUsuario([FromQuery] Guid idUsuario)
        {
            IEnumerable<ListaVisualizacion> listaVisualizaciones = await _listaVisualizacionFlujo.ObtenerListaCompletaPorUsuario(idUsuario);

            if (listaVisualizaciones == null || !listaVisualizaciones.Any())
            {
                _logger.LogError($"No se encontraron listas de visualización para el usuario con ID {idUsuario}.");
                return (NotFound("No se encontraron listas de visualización."));
            }

            return Ok(listaVisualizaciones);
        }

        [HttpGet("{idMediaLista}")]
        public async Task<IActionResult> ObtenerMediaLista([FromQuery] Guid idMediaLista)
        {
            ListaVisualizacion mediaLista = await _listaVisualizacionFlujo.ObtenerMediaLista(idMediaLista);

            if (mediaLista == null)
            {
                _logger.LogError($"No se encontró la media lista con ID {idMediaLista}.");
                return NotFound("No se encontró la media lista.");
            }

            return Ok(mediaLista);
        }
    }
}

