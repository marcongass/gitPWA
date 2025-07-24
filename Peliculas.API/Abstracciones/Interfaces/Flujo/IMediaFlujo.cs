﻿using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMediaFlujo
    {
        Task<IEnumerable<Media>> ListarMediaPorGenero(bool esPelicula, int genero);
    }
}
