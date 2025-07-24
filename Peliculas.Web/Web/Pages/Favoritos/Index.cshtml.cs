using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Pages.Favoritos
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public IList<Favorito> favoritos { get; set; }

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerFavoritosPorUsuario");
            
            HttpClient cliente = new HttpClient();
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            HttpResponseMessage response = await cliente.SendAsync(solicitud);
            response.EnsureSuccessStatusCode();

            string resultado = await response.Content.ReadAsStringAsync();
            JsonSerializerOptions opciones = new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            };

            favoritos = JsonSerializer.Deserialize<List<Favorito>>(resultado, opciones);
        }
    }
}