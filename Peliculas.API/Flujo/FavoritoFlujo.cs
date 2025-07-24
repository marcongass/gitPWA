using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class FavoritoFlujo : IFavoritoFlujo
    {
        private IFavoritoDA _favoritoDA;
        
        public FavoritoFlujo(IFavoritoDA favoritoDA)
        {
            _favoritoDA = favoritoDA;
        }

        public async Task<Guid> AgregarFavorito(Favorito favorito)
        {
            return await _favoritoDA.AgregarFavorito(favorito);
        }

        public Task<Guid> EditarFavorito(Guid idFavorito, Favorito favorito)
        {
            return _favoritoDA.EditarFavorito(idFavorito, favorito);
        }

        public Task<Guid> EliminarFavorito(Guid idFavorito)
        {
            return _favoritoDA.EliminarFavorito(idFavorito);
        }

        public Task<Favorito> ObtenerFavorito(Guid idFavorito)
        {
            return _favoritoDA.ObtenerFavorito(idFavorito);
        }

        public Task<IEnumerable<Favorito>> ObtenerFavoritosPorUsuario(Guid idUsuario)
        {
            return _favoritoDA.ObtenerFavoritosPorUsuario(idUsuario);
        }
    }
}
