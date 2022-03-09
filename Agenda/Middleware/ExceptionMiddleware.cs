using Agenda.Exceptions;
using System.Net;

namespace Agenda.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is DefaultException error)
                {
                    var response = new Error() { };
                    response.Message = error.ErrorResponse.Message;
                    response.StatusCode = error.ErrorResponse.StatusCode;
                    context.Response.StatusCode = error.ErrorResponse.StatusCode;
                    await context.Response.WriteAsJsonAsync(response);
                } else if (ex is InvalidOperationException err)
                {
                    var response = new Error() { };
                    response.Message = err.Message;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsJsonAsync(response);
                }
            }

        }
    }
    public class Error
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
