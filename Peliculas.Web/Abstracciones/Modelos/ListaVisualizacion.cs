using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class ListaVisualizacion
    {
        public Guid idListaVisualizacion {  get; set; }
        public int idMedia {  get; set; }
        public int prioridad { get; set; }
        public int estado { get; set; }
        public Guid idUsuario { get; set; }
    }
}
