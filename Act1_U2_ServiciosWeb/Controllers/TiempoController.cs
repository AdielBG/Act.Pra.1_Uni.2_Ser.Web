using Microsoft.AspNetCore.Mvc;

namespace Act1_U2_ServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/tiempo")]
    public class TiempoController : ControllerBase
    {
        // GET /api/tiempo/formatear
        [HttpGet("formatear")]
        public IActionResult Formatear([FromQuery] int segundos)
        {
            if (segundos < 0)
            {
                return BadRequest("Los segundos no pueden ser negativos.");
            }

            // Calcular horas: cuántas veces caben 3600 segundos
            int horas = segundos / 3600;

            // Calcular minutos: del resto que quedó, cuántas veces caben 60
            int minutosRestantes = segundos % 3600;
            int minutos = minutosRestantes / 60;

            // Calcular segundos restantes
            int segsRestantes = segundos % 60;

            // Armar el formato HH:MM:SS con dos dígitos cada parte
            string formato = horas.ToString("D2") + ":"
                           + minutos.ToString("D2") + ":"
                           + segsRestantes.ToString("D2");

            return Ok(new
            {
                horas = horas,
                minutos = minutos,
                segundos = segsRestantes,
                formato = formato
            });
        }
    }
}