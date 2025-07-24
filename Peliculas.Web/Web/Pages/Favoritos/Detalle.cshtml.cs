using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Favoritos
{
    public class DetalleModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public Favorito favorito { get; set; } = default;

        public DetalleModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet(Guid? idFavorito)
        {
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
        }
    }
}
