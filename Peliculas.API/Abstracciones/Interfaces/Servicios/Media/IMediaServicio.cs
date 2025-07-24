namespace Abstracciones.Interfaces.Servicios.Media
{
    public interface IMediaServicio
    {
        Task<IEnumerable<Abstracciones.Modelos.Media>> ListarMediaPorGenero(bool esPelicula, int genero);
    }
}