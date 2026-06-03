using Microsoft.AspNetCore.Mvc;

namespace Act1_U2_ServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/edad")]
    public class EdadController : ControllerBase
    {
        // GET /api/edad/calcular
        [HttpGet("calcular")]
        public IActionResult Calcular([FromQuery] DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;

            // Calcular la edad en años
            int edad = hoy.Year - fechaNacimiento.Year;

            // Si todavía no ha llegado el cumpleaños este año, restamos 1
            if (fechaNacimiento.Month > hoy.Month)
            {
                edad = edad - 1;
            }
            else if (fechaNacimiento.Month == hoy.Month && fechaNacimiento.Day > hoy.Day)
            {
                edad = edad - 1;
            }

            // Determinar el signo zodiacal
            string signo = ObtenerSigno(fechaNacimiento.Month, fechaNacimiento.Day);

            return Ok(new
            {
                fechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd"),
                edad = edad,
                signoZodiacal = signo
            });
        }

        private string ObtenerSigno(int mes, int dia)
        {
            string signo;

            if ((mes == 3 && dia >= 21) || (mes == 4 && dia <= 19))
            {
                signo = "Aries";
            }
            else if ((mes == 4 && dia >= 20) || (mes == 5 && dia <= 20))
            {
                signo = "Tauro";
            }
            else if ((mes == 5 && dia >= 21) || (mes == 6 && dia <= 20))
            {
                signo = "Géminis";
            }
            else if ((mes == 6 && dia >= 21) || (mes == 7 && dia <= 22))
            {
                signo = "Cáncer";
            }
            else if ((mes == 7 && dia >= 23) || (mes == 8 && dia <= 22))
            {
                signo = "Leo";
            }
            else if ((mes == 8 && dia >= 23) || (mes == 9 && dia <= 22))
            {
                signo = "Virgo";
            }
            else if ((mes == 9 && dia >= 23) || (mes == 10 && dia <= 22))
            {
                signo = "Libra";
            }
            else if ((mes == 10 && dia >= 23) || (mes == 11 && dia <= 21))
            {
                signo = "Escorpio";
            }
            else if ((mes == 11 && dia >= 22) || (mes == 12 && dia <= 21))
            {
                signo = "Sagitario";
            }
            else if ((mes == 12 && dia >= 22) || (mes == 1 && dia <= 19))
            {
                signo = "Capricornio";
            }
            else if ((mes == 1 && dia >= 20) || (mes == 2 && dia <= 18))
            {
                signo = "Acuario";
            }
            else
            {
                signo = "Piscis";
            }

            return signo;
        }
    }
}