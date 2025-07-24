namespace Abstracciones.Modelos
{
    public class Media
    {
        public int idMedia { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public decimal Calificacion { get; set; }
        private bool EsPelicula { get; set; }
    }
}
