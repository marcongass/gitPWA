using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios.Generos;
using Abstracciones.Modelos;
using System.Text.Json;

namespace Servicios
{
    public class GeneroServicio : IGeneroServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public GeneroServicio(IConfiguracion configuracion, IHttpClientFactory httpClientFactory)
        {
            _configuracion = configuracion;
            _httpClient = httpClientFactory;
        }

        public async Task<IEnumerable<Genero>> ObtenerGeneros(string tipo)
        {
            var endpoint = _configuracion.ObtenerMetodo("ApiEndpointObtenerGeneros", "ObtenerGeneros").Replace("{0}", tipo);
            var servicioGeneros = _httpClient.CreateClient("ServicioGeneros");
            var respuesta = await servicioGeneros.GetAsync(endpoint);
            respuesta.EnsureSuccessStatusCode();
            var contenido = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultadoDeserializado = JsonSerializer.Deserialize<RespuestaGenero>(contenido, opciones);
            return resultadoDeserializado.Genres;
        }

        private class RespuestaGenero
        {
            public List<Genero> Genres { get; set; }
        }
    }
}
