using System.Net;
using System.Text.Json;
using wallet.lib.logger;

namespace Api;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerManager _logger;
    
    public LoggerMiddleware(RequestDelegate next, ILoggerManager logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var originalBody = context.Response.Body;
        
        try
        {
            _logger.LogInfo("----------------------------------------------------------------------------------------------------");
            _logger.LogInfo("Service "+context.Request.Path.Value+" requested");

            using var memStream = new MemoryStream();
            context.Response.Body = memStream;
            await _next(context);
            memStream.Position = 0;
            var response = await new StreamReader(memStream).ReadToEndAsync();
            memStream.Position = 0;
            await memStream.CopyToAsync(originalBody);

            if (response.Contains("\"isSuccess\":true")) 
                _logger.LogInfo(response);
            else
                _logger.LogWarn(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            context.Response.Body = originalBody;
            await HandleExceptionAsync(context, ex);
        }
    }

    private class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    
    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
        await context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = ex.Message
        }.ToString());
    }
}
