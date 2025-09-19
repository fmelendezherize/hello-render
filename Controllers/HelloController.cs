using Microsoft.AspNetCore.Mvc;

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
    }
}
