using Microsoft.AspNetCore.Mvc;
using API_BASE_FCT.Repositories;

namespace API_BASE_FCT.Controllers
{
    [ApiController]
    [Route("api/v1/testplan")]
    public class TestPlanController : ControllerBase
    {
        private readonly ITestPlanRepository _repository;

        // INJEÇÃO DE PEDENDÊNCIA: O .NET VAI ENTREGAR O REPOSITÓRIO PRONTO AQUI!
    
    public TestPlanController(ITestPlanRepository repository)
    {
        _repository = repository;
    }

    // Define que este método responde a um GET 
    [HttpGet]
        public IActionResult Get([FromQuery] string fingerprint)
        {
            // 1. validação: O tablet mandou o fingerprint vazio?
            if (string.IsNullOrWhiteSpace(fingerprint))
            {
                return BadRequest(new
                {
                    error = "Bad Request",
                    message = "O parâmetro 'fingerprint' é obrigatório e não pode ser vazio."
                });
            }
            // 2. consulta: Vamos pedir para o repositório buscar um plano de teste com o fingerprint informado
            var plan = _repository.GetTestPlanByFingerprint(fingerprint);

            //3. validação: O repositório encontrou um plano de teste para o fingerprint informado? 
            if (plan == null)
            {
                return NotFound(new
                {
                    error = "Not Found",
                    message = $"Nenhum plano de teste encontrado para o fingerprint '{fingerprint}'."
                });
            }
            // 4. resposta: Encontramos um plano de teste, vamos devolver ele para o tablet
            return Ok(plan);
        }
    }
}   
