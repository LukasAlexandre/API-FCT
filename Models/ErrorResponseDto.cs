namespace API_BASE_FCT.Models
{
    public class ErrorResponseDto
    {
        public int statusCode { get; set; }
        public required string error { get; set; } = string.Empty;
        public required string message { get; set; } = string.Empty;
        public required string traceid { get; set; } = string.Empty;
        public DateTime timestamp { get; set; }

    }
}
