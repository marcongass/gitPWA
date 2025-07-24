using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class ListaVisualizacionDA : IListaVisualizacionDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _conexion;

        public ListaVisualizacionDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _conexion = _repositorioDapper.ObtenerConexion();
        }

        public async Task<Guid> AgregarMediaLista(ListaVisualizacion mediaListaVisualizacion)
        {
            string sqlQuery = "AgregarMediaLista";

            Guid resultadoConsulta = await _conexion.ExecuteScalarAsync<Guid>(sqlQuery, new
            {
                idListaVisualizacion = mediaListaVisualizacion.idListaVisualizacion,
                idMedia = mediaListaVisualizacion.idMedia,
                prioridad = mediaListaVisualizacion.prioridad,
                estado = mediaListaVisualizacion.estado,
                idUsuario = mediaListaVisualizacion.idUsuario
            });

            return resultadoConsulta;

        }

        public async Task<Guid> EditarMediaLista(Guid idMediaLista, ListaVisualizacion mediaListaVisualizacion)
        {
            await verificarMediaLista(idMediaLista);

            string sqlQuery = "EditarMediaLista";

            Guid resultadoConsulta = await _conexion.ExecuteScalarAsync<Guid>(sqlQuery, new
            {
                idListaVisualizacion = idMediaLista,
                prioridad = mediaListaVisualizacion.prioridad,
                estado = mediaListaVisualizacion.estado
            });

            return resultadoConsulta;
        }

        public async Task<Guid> EliminarMediaLista(Guid idMediaLista)
        {
            await verificarMediaLista(idMediaLista);

            string sqlQuery = "EliminarMediaLista";

            Guid resultado = await _conexion.ExecuteScalarAsync<Guid>(sqlQuery, new
            {
                idListaVisualizacion = idMediaLista
            });

            return resultado;
        }

        public async Task<IEnumerable<ListaVisualizacion>> ObtenerListaCompletaPorUsuario(Guid idUsuario)
        {
            string sqlQuery = "ObtenerListaCompletaPorUsuario";

            IEnumerable<ListaVisualizacion> resultadoConsulta = await _conexion.QueryAsync<ListaVisualizacion>(sqlQuery, new
            {
                idUsuario = idUsuario
            });

            return resultadoConsulta;
        }

        public async Task<ListaVisualizacion> ObtenerMediaLista(Guid idMediaLista)
        {
            string sqlQuery = "ObtenerMediaLista";

            IEnumerable<ListaVisualizacion> resultadoConsulta = await _conexion.QueryAsync<ListaVisualizacion>(sqlQuery, new
            {
                idListaVisualizacion = idMediaLista
            });

            return resultadoConsulta.FirstOrDefault();
        }

        private async Task verificarMediaLista(Guid idMediaLista)
        {
            ListaVisualizacion? mediaLista = await ObtenerMediaLista(idMediaLista);

            if (mediaLista == null)
            {
                throw new Exception("La media lista no existe.");
            }
        }
    }
}
