using Microsoft.AspNetCore.Mvc;

namespace Act1_U2_ServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/imc")]
    public class ImcController : ControllerBase
    {
        // GET /api/imc/calcular
        [HttpGet("calcular")]
        public IActionResult Calcular([FromQuery] double peso, [FromQuery] double altura)
        {
            if (peso <= 0 || altura <= 0) // Peso: kilogramos (kg) - Altura: metros(m)
            {
                return BadRequest("El peso y la altura deben ser valores positivos.");
            }

            // Fórmula del IMC: peso dividido entre la altura al cuadrado
            double imc = peso / (altura * altura);

            // Redondear a 2 decimales
            imc = Math.Round(imc, 2);

            // Determinar la categoría
            string categoria;
            if (imc < 18.5)
            {
                categoria = "Bajo peso";
            }
            else if (imc < 25.0)
            {
                categoria = "Normal";
            }
            else if (imc < 30.0)
            {
                categoria = "Sobrepeso";
            }
            else
            {
                categoria = "Obesidad";
            }

            return Ok(new
            {
                peso = peso,
                altura = altura,
                imc = imc,
                categoria = categoria
            });
        }
    }
}