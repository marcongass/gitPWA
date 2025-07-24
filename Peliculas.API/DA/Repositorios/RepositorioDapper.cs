using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Reglas;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuracion;
        private readonly SqlConnection _conexion;

        public RepositorioDapper(IConfiguration configuracion)
        {
            _configuracion = configuracion;
            _conexion = new SqlConnection(_configuracion.GetConnectionString("BD"));
        }

        public SqlConnection ObtenerConexion()
        { 
            return _conexion;
        }
    }
}
