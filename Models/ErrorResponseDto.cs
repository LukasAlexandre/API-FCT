namespace API_BASE_FCT.Models
{
    public class ErrorResponseDto
    {
        public int statusCode { get; set; }
        public required string error { get; set; }
        public string message { get; set; }
        public string traceid { get; set; }
        public DateTime timestamp { get; set; }

    }
}
