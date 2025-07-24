using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios.Generos;
using Abstracciones.Modelos;

namespace Flujo
{
    public class GeneroFlujo : IGeneroFlujo
    {
        private IGeneroServicio _generoServicio;

        public GeneroFlujo(IGeneroServicio generoServicio)
        {
            _generoServicio = generoServicio;
        }

        public async Task<IEnumerable<Genero>> ObtenerGeneros(string tipo)
        {
            return await _generoServicio.ObtenerGeneros(tipo);
        }
    }
}
