using ExceptionHandling.Domain.DomainExceptions;
using System.Net;

namespace ExceptionHandling.Api.CustomMiddleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAysnc(context, ex);
            }
        }

        private static async Task HandleExceptionAysnc(HttpContext context, Exception ex)
        {
            if (ex is DomainNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
