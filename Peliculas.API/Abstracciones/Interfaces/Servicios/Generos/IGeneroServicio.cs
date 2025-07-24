using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Servicios.Generos
{
    public interface IGeneroServicio
    {
        Task<IEnumerable<Genero>> ObtenerGeneros(string tipo);
    }
}
