using System.IO;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace API_BASE_FCT.Repositories
{
    public class InMemoryTestPlanRepository : ITestPlanRepository
    {

        private readonly List<TestPlanDto> _testPlans;
        public InMemoryTestPlanRepository()
        {

            string JsonString = File.ReadAllText("Mocks/Testplan.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var mockPlan = JsonSerializer.Deserialize<TestPlanDto>(JsonString, options);

            if (mockPlan == null)
            {
                throw new InvalidOperationException("Falha ao desserializar o arquivo Testplan.json");
            }
            _testPlans = new List<TestPlanDto> { mockPlan };
        }
        public TestPlanDto GetTestPlanByFingerprint(string fingerprint)
        {


            return _testPlans.FirstOrDefault(plan =>

            plan != null && 
            plan.Product != null &&
            plan.Product.FirmwareConstraint != null &&
            plan.Product.FirmwareConstraint.MinBuildFingerprint == fingerprint);

        }
    }
}
