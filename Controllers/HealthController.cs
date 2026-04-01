
using API_BASE_FCT.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_BASE_FCT.Controllers
{
    [ApiController]
    [Route("health")]


    public class HealthController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(HealthResponseDto), StatusCodes.Status200OK)]

        public IActionResult Get()
        {

            var response = new HealthResponseDto
            {

                status = "Healthy",
                timestamp = DateTime.Now,
                version = "v1"
            };
            return Ok(response);
        }
        
    }
}
