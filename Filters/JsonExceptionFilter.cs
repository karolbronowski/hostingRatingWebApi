using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hostingRatingWebApi.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new ObjectResult(new
            {
                code = 500,
                message = "Oops, something went wrong. :(",
                detailedMessage = context.Exception.Message
            });

            result.StatusCode = 500;
            context.Result = result;
        }

    }
}