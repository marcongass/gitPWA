using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Series
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public IList<Media> series { get; set; }
        public IList<Genero> generos { get; set; }

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet(int? idGenero)
        {
            if (idGenero == null)
            {
                idGenero = 16;
            }

            string endpointGeneros = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerGeneros");
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerSeries");

            HttpClient clienteGeneros = new HttpClient();
            HttpClient clienteSeries = new HttpClient();

            HttpRequestMessage solicitudGeneros = new HttpRequestMessage(HttpMethod.Get, string.Format(endpointGeneros, "tv"));
            HttpRequestMessage solicitudSeries = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, idGenero));

            HttpResponseMessage responseSeries = await clienteSeries.SendAsync(solicitudSeries);
            HttpResponseMessage responseGeneros = await clienteGeneros.SendAsync(solicitudGeneros);
            responseSeries.EnsureSuccessStatusCode();
            responseGeneros.EnsureSuccessStatusCode();

            string resultadoSeries = await responseSeries.Content.ReadAsStringAsync();
            string resultadoGeneros = await responseGeneros.Content.ReadAsStringAsync();

            JsonSerializerOptions opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            generos = JsonSerializer.Deserialize<List<Genero>>(resultadoGeneros, opciones);
            series = JsonSerializer.Deserialize<List<Media>>(resultadoSeries, opciones);
        }

        public async Task<IActionResult> OnPost(int idMedia, string comentario, int puntuacion)
        {
            Favorito favorito = new Favorito
            {
                idMedia = idMedia,
                Comentario = comentario,
                Puntuacion = puntuacion,
                idUsuario = Guid.Parse("F0F02BEC-B764-4E48-AACE-ED1E35775A9C")
            };

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarFavorito");
            HttpClient cliente = new HttpClient();
            StringContent contenido = new StringContent(JsonSerializer.Serialize(favorito), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await cliente.PostAsync(endpoint, contenido);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al agregar el favorito.");
                return Page();
            }
        }
    }
}
