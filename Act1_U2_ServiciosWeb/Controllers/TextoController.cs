using Microsoft.AspNetCore.Mvc;

namespace ApiServiciosWeb.Controllers
{
    [ApiController]
    [Route("api/texto")]
    public class TextoController : ControllerBase
    {
        // GET /api/texto/contar
        [HttpGet("contar")]
        public IActionResult Contar([FromQuery] string texto)
        {
            if (texto == null || texto == "")
            {
                return BadRequest("Debe ingresar un texto.");
            }

            // Contar palabras separando por espacios
            string[] palabras = texto.Split(' ');
            int cantidadPalabras = 0;
            foreach (string palabra in palabras)
            {
                if (palabra != "")
                {
                    cantidadPalabras++;
                }
            }

            // Contar caracteres (incluyendo espacios)
            int cantidadCaracteres = texto.Length;

            // Contar vocales recorriendo letra por letra
            string vocales = "aeiouAEIOUáéíóúÁÉÍÓÚ";
            int cantidadVocales = 0;
            foreach (char letra in texto)
            {
                if (vocales.Contains(letra))
                {
                    cantidadVocales++;
                }
            }

            return Ok(new
            {
                texto = texto,
                cantidadPalabras = cantidadPalabras,
                cantidadCaracteres = cantidadCaracteres,
                cantidadVocales = cantidadVocales
            });
        }

        // GET /api/texto/invertir?texto=Hola
        [HttpGet("invertir")]
        public IActionResult Invertir([FromQuery] string texto)
        {
            if (texto == null || texto == "")
            {
                return BadRequest("Debe ingresar un texto.");
            }

            // Invertir el texto carácter por carácter
            string invertido = "";
            for (int i = texto.Length - 1; i >= 0; i--)
            {
                invertido = invertido + texto[i];
            }

            return Ok(new
            {
                original = texto,
                invertido = invertido
            });
        }
    }
}
