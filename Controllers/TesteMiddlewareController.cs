using Microsoft.AspNetCore.Mvc;

namespace PoupaDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteMiddlewareController : ControllerBase
    {
        [HttpGet("exception-middleware")]
        public IActionResult TesteMiddlewareException()
        {
            throw new Exception("Teste middleware exception");
        }
    }
}
