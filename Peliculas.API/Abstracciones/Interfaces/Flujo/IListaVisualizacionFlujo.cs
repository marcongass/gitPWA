using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IListaVisualizacionFlujo
    {
        Task<IEnumerable<ListaVisualizacion>> ObtenerListaCompletaPorUsuario(Guid idUsuario);
        Task<ListaVisualizacion> ObtenerMediaLista(Guid idMediaLista);
        Task<Guid> AgregarMediaLista(ListaVisualizacion mediaListaVisualizacion);
        Task<Guid> EditarMediaLista(Guid idMediaLista, ListaVisualizacion mediaListaVisualizacion);
        Task<Guid> EliminarMediaLista(Guid idMediaLista);
    }
}
