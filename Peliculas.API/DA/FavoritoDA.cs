using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class FavoritoDA : IFavoritoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _conexion;

        public FavoritoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _conexion = _repositorioDapper.ObtenerConexion();
        }

        public async Task<Guid> AgregarFavorito(Favorito favorito)
        {
            string sqlQuery = "AgregarFavorito";

            Guid resultadoConsulta = await _conexion.ExecuteScalarAsync<Guid>(sqlQuery, new
            {
                idFavorito = favorito.idFavorito,
                idMedia = favorito.idMedia,
                Comentario = favorito.Comentario,
                Puntuacion = favorito.Puntuacion,
                idUsuario = favorito.idUsuario
            });

            return resultadoConsulta;
        }

        public async Task<Guid> EditarFavorito(Guid idFavorito, Favorito favorito)
        {
            await verificarFavorito(idFavorito);

            string sqlQuery = "EditarFavorito";

            Guid resultadoConsulta = await _conexion.ExecuteScalarAsync<Guid>(sqlQuery, new
            {
                idFavorito = idFavorito,
                Comentario = favorito.Comentario,
                Puntuacion = favorito.Puntuacion
            });

            return resultadoConsulta;
        }

        public async Task<Guid> EliminarFavorito(Guid idFavorito)
        {
            await verificarFavorito(idFavorito);

            string sqlQuery = "EliminarFavorito";

            Guid resultadoConsulta = await _conexion.ExecuteScalarAsync<Guid>(sqlQuery, new
            {
                idFavorito = idFavorito
            });

            return resultadoConsulta;
        }

        public async Task<Favorito> ObtenerFavorito(Guid idFavorito)
        {
            string sqlQuery = "ObtenerFavorito";

            IEnumerable<Favorito> resultadoConsulta = await _conexion.QueryAsync<Favorito>(sqlQuery, new
            {
                idFavorito = idFavorito
            });

            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<IEnumerable<Favorito>> ObtenerFavoritosPorUsuario(Guid idUsuario)
        {
            string sqlQuery = "ObtenerFavoritosPorUsuario";

            IEnumerable<Favorito> resultadoConsulta = await _conexion.QueryAsync<Favorito>(sqlQuery, new
            {
                idUsuario = idUsuario
            });

            return resultadoConsulta;
        }

        private async Task verificarFavorito(Guid id)
        {
            Favorito? resultadoVerificacion = await ObtenerFavorito(id);

            if (resultadoVerificacion == null)
            {
                throw new Exception("El favorito no existe.");
            }
        }
    }
}