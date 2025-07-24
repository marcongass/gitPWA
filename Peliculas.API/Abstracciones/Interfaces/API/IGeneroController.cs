using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IGeneroController
    {
        Task<IActionResult> ObtenerGeneros(string tipo);
    }
}
