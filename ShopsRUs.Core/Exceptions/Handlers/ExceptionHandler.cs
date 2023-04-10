using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Exceptions.Handlers
{
    public abstract class ExceptionHandler
    {
        public Task HandleExceptionAsync(Exception exception)
        {
            if (exception is BusinessException businessException)
                return HandleException(businessException);

            else if (exception is ValidationException validationException)
                return HandleException(validationException);

            else return HandleException(exception);
        }

        protected abstract Task HandleException(BusinessException businessException);
        protected abstract Task HandleException(ValidationException validationException);
        protected abstract Task HandleException(Exception exception);
    }
}
