using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IListaVisualizacionController
    {
        Task<IActionResult> ObtenerListaCompletaPorUsuario(Guid idUsuario);
        Task<IActionResult> ObtenerMediaLista(Guid idMediaLista);
        Task<IActionResult> AgregarMediaLista(ListaVisualizacion mediaListaVisualizacion);
        Task<IActionResult> EditarMediaLista(Guid idMediaLista, ListaVisualizacion mediaListaVisualizacion);
        Task<IActionResult> EliminarMediaLista(Guid idMediaLista);
    }
}
