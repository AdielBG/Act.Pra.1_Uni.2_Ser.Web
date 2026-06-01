using Microsoft.AspNetCore.Mvc;

namespace Act1_U2_ServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/hola")]
    public class HolaController : ControllerBase
    {
        // GET /api/hola/saludo?nombre=Adiel
        [HttpGet("saludo")]
        public IActionResult Saludo([FromQuery] string nombre)
        {
            // Verifica que el nombre no venga vacío
            if (nombre == null || nombre == "")
            {
                return BadRequest("Debe ingresar un nombre.");
            }

            // Creamos el mensaje de bienvenida
            string mensaje = "Bienvenido, " + nombre + "! Nos alegra tenerte aquí.";

            return Ok(new { mensaje = mensaje });
        }
    }
}