using System.ComponentModel.DataAnnotations;
using System.Net;
using Newtonsoft.Json;

namespace ArchitectureApi.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException e)
        {
            await HandleValidationExceptionAsync(context, e);
        }
        catch
        {
            await HandleUnexpectedExceptionAsync(context);
        }
    }
   
    private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        var code = HttpStatusCode.BadRequest;
        var result = JsonConvert.SerializeObject(new
        {
            error = exception.Message
        });
        return WriteErrorToJson(context, result, code);
    }

    private static Task HandleUnexpectedExceptionAsync(HttpContext context)
    {
        var code = HttpStatusCode.BadRequest;
        var message = "Unexpected error occurred.";
        var result = JsonConvert.SerializeObject(new
        {
            error = message
        });
        return WriteErrorToJson(context, result, code);
    }
    private static Task WriteErrorToJson(HttpContext context, string result, HttpStatusCode code)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}