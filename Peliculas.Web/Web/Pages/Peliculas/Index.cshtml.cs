using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Peliculas
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public IList<Media> peliculas { get; set; }
        public IList<Genero> generos { get; set; }

        [BindProperty]
        public Favorito favorito { get; set; }

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
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerPeliculas");

            HttpClient clienteGeneros = new HttpClient();
            HttpClient cliente = new HttpClient();

            HttpRequestMessage solicitudGeneros = new HttpRequestMessage(HttpMethod.Get, string.Format(endpointGeneros, "movie"));
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, idGenero));

            HttpResponseMessage response = await cliente.SendAsync(solicitud);
            HttpResponseMessage responseGeneros = await clienteGeneros.SendAsync(solicitudGeneros);
            response.EnsureSuccessStatusCode();
            responseGeneros.EnsureSuccessStatusCode();

            string resultado = await response.Content.ReadAsStringAsync();
            string resultadoGeneros = await responseGeneros.Content.ReadAsStringAsync();

            JsonSerializerOptions opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            generos = JsonSerializer.Deserialize<List<Genero>>(resultadoGeneros, opciones);
            peliculas = JsonSerializer.Deserialize<List<Media>>(resultado, opciones);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarFavorito");

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, favorito);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("Index");
        }
    }
}
