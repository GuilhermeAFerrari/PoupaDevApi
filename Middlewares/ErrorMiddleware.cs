using Newtonsoft.Json;
using PoupaDev.API.ViewModels;
using System.Net;

namespace PoupaDev.API.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //TODO: Gravar log de erro com o trace Id
            //

            ErrorResponseViewModel errorResponseVm;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
                (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"))
            {
                errorResponseVm = new ErrorResponseViewModel(HttpStatusCode.InternalServerError.ToString(), $"{ex.Message} {ex?.InnerException?.Message}");
            }
            else
            {
                // Para ambientes homologação, produçao...

                errorResponseVm = new ErrorResponseViewModel(HttpStatusCode.InternalServerError.ToString(), "An internal server error has ocurred.");
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(errorResponseVm);
            context.Response.ContentType= "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
