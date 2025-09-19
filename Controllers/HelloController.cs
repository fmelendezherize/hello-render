using Microsoft.AspNetCore.Mvc;
using RenderLab1.Models;

namespace RenderLab1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hola desde mi microservicio en ASP.NET Core!" });
        }

        [HttpPost("")]
        public IActionResult PostGreeting([FromBody] GreetingRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("El nombre es obligatorio.");
            }

            // Crea un saludo largo incluyendo el nombre
            string mensaje = $"Hola, {request.Name}! " +
                "Espero que este día esté lleno de éxito, alegría y mucha energía positiva. " +
                "Recuerda que cada paso que das te acerca más a tus metas, sigue adelante sin miedo. " +
                "Si necesitas ayuda, aquí estoy para apoyarte.";

            return Ok(new { Message = mensaje });
        }
    }
}
