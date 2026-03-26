namespace API_BASE_FCT.Repositories
{
    
    public interface ITestPlanRepository
    {
     TestPlanDto? GetTestPlanByFingerprint(string fingerprint);
    }
}
