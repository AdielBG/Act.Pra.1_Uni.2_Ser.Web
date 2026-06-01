using Microsoft.AspNetCore.Mvc;

namespace   Act1_U2_ServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/numeros")]
    public class NumerosController : ControllerBase
    {
       
        [HttpGet("analizar")]
        public IActionResult Analizar([FromQuery] int n)
        {
            // Verificar si es par o impar
            string paridad;
            if (n % 2 == 0)
            {
                paridad = "Par";
            }
            else
            {
                paridad = "Impar";
            }

            // Verificar si es primo
            string primo;
            if (EsPrimo(n))
            {
                primo = "Es primo";
            }
            else
            {
                primo = "No es primo";
            }

            // Verificar el signo
            string signo;
            if (n > 0)
            {
                signo = "Positivo";
            }
            else if (n < 0)
            {
                signo = "Negativo";
            }
            else
            {
                signo = "Cero";
            }

            return Ok(new
            {
                numero = n,
                paridad = paridad,
                primo = primo,
                signo = signo
            });
        }

        // Método auxiliar para verificar si un número es primo
        private bool EsPrimo(int numero)
        {
            if (numero < 2)
            {
                return false;
            }

            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}