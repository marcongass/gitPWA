using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios.Media;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Servicios
{
    public class MediaServicio : IMediaServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public MediaServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Media>> ListarMediaPorGenero(bool esPelicula, int genero)
        {
            string generoString = genero.ToString();

            if (esPelicula)
            {
                string endpoint = _configuracion.ObtenerMetodo("ApiEndpointObtenerPeliculasGenero", "ObtenerPeliculasPorGenero");
                HttpClient servicioMedia = _httpClient.CreateClient("ServicioMedia");

                HttpResponseMessage response = await servicioMedia.GetAsync(string.Format(endpoint, generoString));
                response.EnsureSuccessStatusCode();

                string peliculas = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                RespuestaPelicula? resultadoDeserializado = JsonSerializer.Deserialize<RespuestaPelicula>(peliculas, opciones);

                return resultadoDeserializado?.Results?.Select(x => new Media
                {
                    idMedia = x.Id,
                    Titulo = x.Title,
                    Imagen = x.PosterPath,
                    Descripcion = x.Overview,
                    Fecha = x.ReleaseDate,
                    Calificacion = (decimal)x.VoteAverage
                }) ?? Enumerable.Empty<Media>();

            }
            else
            {
                string endpoint = _configuracion.ObtenerMetodo("ApiEndpointObtenerSeriesGenero", "ObtenerSeriesPorGenero");
                HttpClient servicioMedia = _httpClient.CreateClient("ServicioMedia");

                HttpResponseMessage response = await servicioMedia.GetAsync(string.Format(endpoint, generoString));
                response.EnsureSuccessStatusCode();

                string series = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                RespuestaSerie? resultadoDeserializado = JsonSerializer.Deserialize<RespuestaSerie>(series, opciones);

                return resultadoDeserializado?.Results?.Select(x => new Media
                {
                    idMedia = x.Id,
                    Titulo = x.Name,
                    Imagen = x.PosterPath,
                    Descripcion = x.Overview,
                    Fecha = x.FirstAirDate,
                    Calificacion = (decimal)x.VoteAverage
                }) ?? Enumerable.Empty<Media>();
            }
        }

        private class RespuestaPelicula
        {
            [JsonPropertyName("results")]
            public List<PeliculaApiItem> Results { get; set; }
        }

        private class PeliculaApiItem
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("poster_path")]
            public string PosterPath { get; set; }

            [JsonPropertyName("overview")]
            public string Overview { get; set; }

            [JsonPropertyName("release_date")]
            public string ReleaseDate { get; set; }

            [JsonPropertyName("vote_average")]
            public double VoteAverage { get; set; }
        }

        private class RespuestaSerie
        {
            [JsonPropertyName("results")]
            public List<SerieApiItem> Results { get; set; }
        }

        private class SerieApiItem
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("poster_path")]
            public string PosterPath { get; set; }

            [JsonPropertyName("overview")]
            public string Overview { get; set; }

            [JsonPropertyName("first_air_date")]
            public string FirstAirDate { get; set; }

            [JsonPropertyName("vote_average")]
            public decimal VoteAverage { get; set; }
        }
    }
}
