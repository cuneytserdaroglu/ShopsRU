using Microsoft.AspNetCore.Http;
using ShopsRUs.Core.Exceptions.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler = new();
        private readonly IHttpContextAccessor _contextAccessor;
        //private readonly LoggerServiceBase _loggerService;

        public ExceptionMiddleware(RequestDelegate next, IHttpContextAccessor contextAccessor)//, LoggerServiceBase loggerService)
        {
            _next = next;
            _contextAccessor = contextAccessor;
            //   _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
               
               // Serilog.Log.Error(exception, exception.Message, context);
                await HandleExceptionAsync(context.Response, exception);
            }
        }
        private Task HandleExceptionAsync(HttpResponse response, Exception exception)
        {
            response.ContentType = "application/json";
            _httpExceptionHandler.Response = response;
            return _httpExceptionHandler.HandleExceptionAsync(exception);
        }
    }
}
