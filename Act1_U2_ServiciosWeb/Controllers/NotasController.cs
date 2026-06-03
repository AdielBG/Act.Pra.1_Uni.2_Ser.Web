using Microsoft.AspNetCore.Mvc;

namespace Act1_U2_ServiciosWeb.Controllers
{
    // Clase que representa el cuerpo del JSON que recibimos
    public class NotasRequest
    {
        public List<int> Notas { get; set; }
    }

    [ApiController]
    [Route("api/notas")]
    public class NotasController : ControllerBase
    {
        // POST /api/notas/estadisticas
        [HttpPost("estadisticas")]
        public IActionResult Estadisticas([FromBody] NotasRequest request)
        {
            if (request == null || request.Notas == null || request.Notas.Count == 0)
            {
                return BadRequest("Debe enviar al menos una nota.");
            }

            // Calcular el promedio sumando todas y dividiendo entre la cantidad
            double suma = 0;
            foreach (int nota in request.Notas)
            {
                suma = suma + nota;
            }
            double promedio = suma / request.Notas.Count;

            // Encontrar la nota mayor
            int notaMayor = request.Notas[0];
            foreach (int nota in request.Notas)
            {
                if (nota > notaMayor)
                {
                    notaMayor = nota;
                }
            }

            // Encontrar la nota menor
            int notaMenor = request.Notas[0];
            foreach (int nota in request.Notas)
            {
                if (nota < notaMenor)
                {
                    notaMenor = nota;
                }
            }

            // Contar aprobados (70 o más) y reprobados
            int aprobados = 0;
            int reprobados = 0;
            foreach (int nota in request.Notas)
            {
                if (nota >= 70)
                {
                    aprobados = aprobados + 1;
                }
                else
                {
                    reprobados = reprobados + 1;
                }
            }

            return Ok(new
            {
                promedio = Math.Round(promedio, 2),
                notaMayor = notaMayor,
                notaMenor = notaMenor,
                aprobados = aprobados,
                reprobados = reprobados
            });
        }
    }
}