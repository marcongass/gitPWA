using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Favorito
    {
        public Guid idFavorito { get; set; }
        public int idMedia { get; set; }   
        public string Comentario { get; set; } 
        public decimal Puntuacion { get; set; } 
        public Guid idUsuario { get; set; }
    }
}
