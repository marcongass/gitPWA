using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IFavoritoFlujo
    {
        Task<IEnumerable<Favorito>> ObtenerFavoritosPorUsuario(Guid idUsuario);
        Task<Favorito> ObtenerFavorito(Guid idFavorito);
        Task<Guid> AgregarFavorito(Favorito favorito);
        Task<Guid> EditarFavorito(Guid idFavorito, Favorito favorito);
        Task<Guid> EliminarFavorito(Guid idFavorito);
    }
}
