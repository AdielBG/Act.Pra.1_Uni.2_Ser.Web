using Microsoft.AspNetCore.Mvc;

namespace Act1_U2_ServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/fechas")]
    public class FechasController : ControllerBase
    {
        // GET /api/fechas/diferencia
        [HttpGet("diferencia")]
        public IActionResult Diferencia([FromQuery] DateTime desde, [FromQuery] DateTime hasta)
        {
            // Calcular la diferencia entre las dos fechas
            TimeSpan diferencia = hasta - desde; //restar dos DateTime produce un TimeSpan, que representa una duración.
            int dias = (int)diferencia.TotalDays;

            return Ok(new
            {
                desde = desde.ToString("yyyy-MM-dd"),
                hasta = hasta.ToString("yyyy-MM-dd"),
                diferenciaDias = dias
            });
        }

        // GET /api/fechas/agregar
        [HttpGet("agregar")]
        public IActionResult Agregar([FromQuery] DateTime fecha, [FromQuery] int dias)
        {
            // Sumar los días a la fecha dada
            DateTime nuevaFecha = fecha.AddDays(dias);

            return Ok(new
            {
                fechaOriginal = fecha.ToString("yyyy-MM-dd"),
                diasAgregados = dias,
                nuevaFecha = nuevaFecha.ToString("yyyy-MM-dd")
            });
        }
    }
}