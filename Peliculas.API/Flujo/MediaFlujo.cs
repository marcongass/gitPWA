using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios.Media;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class MediaFlujo : IMediaFlujo
    {
        private IMediaServicio _mediaServicio;

        public MediaFlujo(IMediaServicio mediaServicio)
        {
            _mediaServicio = mediaServicio;
        }

        public async Task<IEnumerable<Media>> ListarMediaPorGenero(bool esPelicula, int genero)
        {
            return await _mediaServicio.ListarMediaPorGenero(esPelicula, genero);
        }
    }
}
