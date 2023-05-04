using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        [HttpGet("hi")]
        public IActionResult Hi()
        {
            return Ok("Hello");
        }
    }
}
