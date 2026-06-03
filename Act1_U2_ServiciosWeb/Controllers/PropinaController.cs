using Microsoft.AspNetCore.Mvc;

namespace Act1_U2_ServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/propina")]
    public class PropinaController : ControllerBase
    {
        // GET /api/propina/calcular
        [HttpGet("calcular")]
        public IActionResult Calcular([FromQuery] double monto, [FromQuery] double porcentaje)
        {
            if (monto <= 0)
            {
                return BadRequest("El monto debe ser mayor a cero.");
            }

            if (porcentaje < 0)
            {
                return BadRequest("El porcentaje no puede ser negativo.");
            }

            // Calcular la propina
            double propina = monto * porcentaje / 100;

            // Calcular el total
            double total = monto + propina;

            return Ok(new
            {
                montoOriginal = monto,
                porcentajePropina = porcentaje,
                propina = Math.Round(propina, 2),
                totalAPagar = Math.Round(total, 2)
            });
        }
    }
}