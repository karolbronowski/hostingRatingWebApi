using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hostingRatingWebApi.Filters
{
      public class ValidatorActionFilter : IActionFilter
       {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
            }
        
        }
    
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var ex = filterContext.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex != null) 
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var error = new 
                {
                    message = ex.Message
                    
                };

                filterContext.HttpContext.Response.ContentType = "application/json";

                filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
            }
            
        }
    }
}