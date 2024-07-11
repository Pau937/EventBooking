using System.Net;

namespace EventBooking.API.Middlewares
{
    public class ErrorsMiddleware(RequestDelegate next, ILogger<ErrorsMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync("Something went wrong.");
            }
        }
    }
}
