using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MegaLTAPI1.Filters
{
    public class MyactionFilter1Attribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            return base.OnActionExecutionAsync(context, next);

        }
    }

	public class MyActionFilterAttribute:Attribute, IAsyncActionFilter
    {		

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            await next();

        }

        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.ExceptionHandled = true;
            }
            throw new NotImplementedException();
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {            
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}

