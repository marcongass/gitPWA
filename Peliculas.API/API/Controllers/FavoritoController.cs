using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase, IFavoritoController
    {
        private IFavoritoFlujo _favoritoFlujo;
        private ILogger<FavoritoController> _logger;

        public FavoritoController(IFavoritoFlujo favoritoFlujo, ILogger<FavoritoController> logger)
        {
            _favoritoFlujo = favoritoFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarFavorito([FromBody] Favorito favorito)
        {
            Guid resultado = await _favoritoFlujo.AgregarFavorito(favorito);

            if (resultado == Guid.Empty)
            {
                _logger.LogError("Error al agregar el favorito.");
                return BadRequest("No se pudo agregar el favorito.");
            }

            return CreatedAtAction(nameof(ObtenerFavorito), new { idFavorito = resultado }, null);
        }

        [HttpPut]
        public async Task<IActionResult> EditarFavorito([FromQuery] Guid idFavorito, [FromBody] Favorito favorito)
        {
            Guid resultado = await _favoritoFlujo.EditarFavorito(idFavorito, favorito);

            if (resultado == Guid.Empty)
            {
                _logger.LogError("Error al editar el favorito.");
                return BadRequest("No se pudo editar el favorito.");
            }

            return Ok(resultado);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarFavorito([FromQuery] Guid idFavorito)
        {
            Guid resultado = await _favoritoFlujo.EliminarFavorito(idFavorito);

            if (resultado == null)
            {
                _logger.LogError("Error al eliminar el favorito.");
                return BadRequest("No se pudo eliminar el favorito.");
            }

            return NoContent();
        }

        [HttpGet("{idFavorito}")]
        public async Task<IActionResult> ObtenerFavorito([FromRoute] Guid idFavorito)
        {
            Favorito favorito = await _favoritoFlujo.ObtenerFavorito(idFavorito);

            if (favorito == null)
            {
                _logger.LogError($"Favorito con ID {idFavorito} no encontrado.");
                return NotFound("Favorito no encontrado.");
            }

            return Ok(favorito);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerFavoritosPorUsuario([FromQuery] Guid idUsuario)
        {
            IEnumerable<Favorito> favoritos = await _favoritoFlujo.ObtenerFavoritosPorUsuario(idUsuario);

            if (favoritos == null || !favoritos.Any())
            {
                _logger.LogError($"No se encontraron favoritos para el usuario con ID {idUsuario}.");
                return NotFound("No se encontraron favoritos para el usuario.");
            }

            return Ok(favoritos);
        }
    }
}
