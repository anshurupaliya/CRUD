using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CRUD.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                // Log the main exception and inner exception if it exists
                if (e.InnerException != null)
                {
                    _logger.LogError("{exceptionType} , {exceptionMessage}", e.InnerException.GetType().ToString(), e.InnerException.Message);
                }
                else
                {
                    _logger.LogError("{exceptionType} , {exceptionMessage}", e.GetType().ToString(), e.Message);
                }

                // Set status code and write error message to response
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("An error occurred while processing your request.");
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
