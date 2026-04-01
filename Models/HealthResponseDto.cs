namespace API_BASE_FCT.Models
{
    public class HealthResponseDto
    {
        public string status { get; set; } = string.Empty;
        public DateTime timestamp { get; set; }
        public string version { get; set; } = string.Empty;
    }
}
