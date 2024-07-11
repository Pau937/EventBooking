using System.Net;

namespace EventBooking.API.Middlewares
{
    public class ErrorsMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                //TODO: error logging

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync("Something went wrong.");
            }
        }
    }
}
