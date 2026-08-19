namespace Ecommerce.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
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
            catch (Exception ex)
            {
                //Log the exception (you can use a logging framework like Serilog, NLog, etc.) and
                //return a custom error response to the client
                _logger.LogError($"{ex.GetType().ToString()}:{ex.Message}");
                
                if(ex.InnerException is not null)
                {
                    _logger.LogError($"{ex.InnerException.GetType().ToString()}:{ex.InnerException.Message}");
                }

                httpContext.Response.StatusCode = 500; // Internal Server Error
                
                await httpContext.Response.WriteAsJsonAsync(
                    new { Message = ex.Message, Type = ex.GetType().ToString() });

                // Do not call the next middleware since an exception has occurred
                // await _next(httpContext);
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
