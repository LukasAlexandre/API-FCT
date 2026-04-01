using Microsoft.AspNetCore.Mvc;
using API_BASE_FCT.Repositories;

namespace API_BASE_FCT.Controllers
{
    [ApiController]
    [Route("testplan")]
    public class TestPlanController : ControllerBase
    {
        private readonly ITestPlanRepository _repository;

    
    public TestPlanController(ITestPlanRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
        public IActionResult Get([FromQuery] string fingerprint)
        {

            if (string.IsNullOrWhiteSpace(fingerprint))
            {
                return BadRequest(new
                {
                    error = "Bad Request",
                    message = "O parâmetro 'fingerprint' é obrigatório e não pode ser vazio."
                });
            }

            var plan = _repository.GetTestPlanByFingerprint(fingerprint);


            if (plan == null)
            {
                return NotFound(new
                {
                    error = "Not Found",
                    message = $"Nenhum plano de teste encontrado para o fingerprint '{fingerprint}'."
                });
            }

            return Ok(plan);
        }
    }
}   
