using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopsRUs.Core.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse? _response;

        public HttpResponse Response
        {
            get => _response ?? throw new ArgumentNullException(nameof(_response));
            set => _response = value;
        }

        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(businessException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(ValidationException validationException)
        {
            throw new NotImplementedException();
        }

        protected override Task HandleException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
