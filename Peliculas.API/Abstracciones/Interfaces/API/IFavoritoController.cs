using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IFavoritoController
    {
        Task<IActionResult> ObtenerFavoritosPorUsuario(Guid idUsuario);
        Task<IActionResult> ObtenerFavorito(Guid idFavorito);
        Task<IActionResult> AgregarFavorito(Favorito favorito);
        Task<IActionResult> EditarFavorito(Guid idFavorito, Favorito favorito);
        Task<IActionResult> EliminarFavorito(Guid idFavorito);
    }
}
