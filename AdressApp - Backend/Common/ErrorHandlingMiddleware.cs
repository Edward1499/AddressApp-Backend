using AddressApp.BLL.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AdressApp___Backend.Common
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private int code = (int)HttpStatusCode.InternalServerError;
        private string title = "Error";
        private string message = "Ha ocurrido un error interno en el servidor.";

        public ErrorHandlingMiddleware(RequestDelegate next)
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
                await HandleException(context, ex);
            }

        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            if (ex is BaseException exception)
            {
                code = exception.Code;
                title = exception.Title;
                message = exception.Detail;
            }

            var result = JsonConvert.SerializeObject(new
            {
                Title = title,
                Error = message,
                Code = code,
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
