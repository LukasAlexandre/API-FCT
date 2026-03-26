using System.IO;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace API_BASE_FCT.Repositories
{
    public class InMemoryTestPlanRepository : ITestPlanRepository
    {
        // Essa lista é o nosso banco de dados em memória
        // como o repositório será um singleton, essa lista vai durar enquanto a aplicação estiver rodando

        private readonly List<TestPlanDto> _testPlans;

        // No construtor do repositório, vamos carregar os dados do arquivo JSON para a lista em memória
        public InMemoryTestPlanRepository()
        {
            // 1. Lemos o arquivo fisico json do disco
            // atenção: garanta que o caminho bate com o onde voce salvou o arquivo
            string JsonString = File.ReadAllText("Mocks/Testplan.json");

            // 2. Opções para ignorar letras maiusculas e minusculas na hora de converter o json para objeto

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // 3. Convertendo o json para um objeto do tipo TestPlanDto
            var mockPlan = JsonSerializer.Deserialize<TestPlanDto>(JsonString, options);

            //4. Guardammos na nossa lista em memória (tabela)
            _testPlans = new List<TestPlanDto> { mockPlan };
        }
        public TestPlanDto GetTestPlanByFingerprint(string fingerprint)
        {
            // MÁGICA DO LINQ (O equivalente ao SELECT do banco de dados)
            // Vamos produrar na lista o primeiro plano onde o fingerprint informado na URL
            // Seja igual ao fingerprint cadastrado dentro do product -> firmawareConstraint.

            return _testPlans.FirstOrDefault(plan =>

            // Verificamos se o plano existe, se o produto existe, se a constraint existe e se o fingerprint bate
            plan != null && 
            plan.product != null &&
            plan.product.firmwareConstraint != null &&
            plan.product.firmwareConstraint.minBuildFingerprint == fingerprint);

        }
    }
}
