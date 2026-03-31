using System.Text.Json;
using API_BASE_FCT.Models;

namespace API_BASE_FCT.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(ex, "Arquivo não encontrado durante o processamento da requisição");
                await WriteErrorResponseAsync(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error",
                    "Arquivo necessário para a execução da API não foi encontrado!");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Erro ao processar JSON.");
                await WriteErrorResponseAsync(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error",
                    "Erro ao processar os dados Json da aplicação");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado durante a aplicação");
                await WriteErrorResponseAsync(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error",
                    "Ocorreu um erro interno na API");
            }
        }
        private static async Task WriteErrorResponseAsync(
            HttpContext context,
            int statusCode,
            string error,
            string message)
            {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ErrorResponseDto
            {
                statusCode = statusCode,
                error = error,
                message = message,
                traceid = context.TraceIdentifier,
                timestamp = DateTime.UtcNow
            };
            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);


        }
       
    }
}
