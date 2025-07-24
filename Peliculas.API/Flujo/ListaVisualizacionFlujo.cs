using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class ListaVisualizacionFlujo : IListaVisualizacionFlujo
    {
        private IListaVisualizacionDA _listaVisualizacionDA;

        public ListaVisualizacionFlujo(IListaVisualizacionDA listaVisualizacionDA)
        {
            _listaVisualizacionDA = listaVisualizacionDA;
        }

        public async Task<Guid> AgregarMediaLista(ListaVisualizacion mediaListaVisualizacion)
        {
            return await _listaVisualizacionDA.AgregarMediaLista(mediaListaVisualizacion);
        }

        public async Task<Guid> EditarMediaLista(Guid idMediaLista, ListaVisualizacion mediaListaVisualizacion)
        {
            return await _listaVisualizacionDA.EditarMediaLista(idMediaLista, mediaListaVisualizacion);
        }

        public async Task<Guid> EliminarMediaLista(Guid idMediaLista)
        {
            return await _listaVisualizacionDA.EliminarMediaLista(idMediaLista);
        }

        public async Task<IEnumerable<ListaVisualizacion>> ObtenerListaCompletaPorUsuario(Guid idUsuario)
        {
            return await _listaVisualizacionDA.ObtenerListaCompletaPorUsuario(idUsuario);
        }

        public async Task<ListaVisualizacion> ObtenerMediaLista(Guid idMediaLista)
        {
            return await _listaVisualizacionDA.ObtenerMediaLista(idMediaLista);
        }
    }
}
