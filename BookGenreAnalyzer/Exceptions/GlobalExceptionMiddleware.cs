using System.Net;
using System.Text.Json;

namespace BookGenreAnalyzer.Exceptions;


public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);  
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception caught.");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = exception switch
        {
            InvalidOperationException _ => HttpStatusCode.BadRequest,
            UnauthorizedAccessException _ => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        };

        
        
        
        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}