using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Favoritos
{
    public class EliminarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public Favorito favorito { get; set; } = default;

        public EliminarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<ActionResult> OnGet(Guid? idFavorito)
        {
            if (idFavorito == Guid.Empty)
            {
                return NotFound();
            }

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerFavorito");

            HttpClient cliente = new HttpClient();
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, idFavorito));
            HttpResponseMessage response = await cliente.SendAsync(solicitud);
            response.EnsureSuccessStatusCode();

            string resultado = await response.Content.ReadAsStringAsync();
            JsonSerializerOptions opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            favorito = JsonSerializer.Deserialize<Favorito>(resultado, opciones);

            return Page();
        }

        public async Task<ActionResult> OnPost(Guid? idFavorito)
        {
            if (idFavorito == Guid.Empty)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EliminarFavorito");

            HttpClient cliente = new HttpClient();
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, idFavorito));
            HttpResponseMessage response = await cliente.SendAsync(solicitud);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("/Favoritos/Index");
        }
    }
}