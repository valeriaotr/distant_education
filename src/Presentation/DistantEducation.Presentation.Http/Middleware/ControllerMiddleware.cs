using System.Text;

namespace DistantEducation.Presentation.Http.Middleware;

public class ControllerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ControllerMiddleware> _logger;

    public ControllerMiddleware(RequestDelegate next, ILogger<ControllerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        string requestBody;
        using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
        {
            requestBody = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;
        }
        _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} {requestBody}");
        await _next(context);
        _logger.LogInformation($"Response: {context.Response.StatusCode}");
    }
}