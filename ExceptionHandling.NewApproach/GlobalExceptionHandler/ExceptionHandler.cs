using ExceptionHandling.Domain.DomainExceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ExceptionHandling.Api.NewApproach
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is DomainNotFoundException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await httpContext.Response.WriteAsync(exception.Message,cancellationToken);
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync(exception.Message,cancellationToken);
            }
            return true; 
        }
    }
}
