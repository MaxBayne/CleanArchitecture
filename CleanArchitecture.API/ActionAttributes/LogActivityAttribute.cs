using CleanArchitecture.API.ActionFilters;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CleanArchitecture.API.ActionAttributes
{
    public class LogActivityAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Method Executed before enter the Action
            Debug.WriteLine($"Executing Action ({context.ActionDescriptor.DisplayName})");

            //Call Next Action Filter or the Action itself
            await next();

            //Method Executed Before Out the Action
            Debug.WriteLine($"Executed Action ({context.ActionDescriptor.DisplayName})");
        }
    }
}
