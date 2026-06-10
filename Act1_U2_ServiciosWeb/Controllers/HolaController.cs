using Microsoft.AspNetCore.Mvc;

namespace Act1_U2_ServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/hola")] //Define la ruta base del controlador.
    public class HolaController : ControllerBase
    {
        // GET /api/hola/saludo
        [HttpGet("saludo")]
        public IActionResult Saludo([FromQuery] string nombre) //Toma el valor nombre de la URL
        {
            // Verifica que el nombre no venga vacío
            if (nombre == null || nombre == "")
            {
                return BadRequest("Debe ingresar un nombre.");
            }

            // Crea el mensaje de bienvenida
            string mensaje = "Bienvenido, " + nombre + "! Nos alegra tenerte aquí.";

            return Ok(new { mensaje = mensaje });
        }
    }
}