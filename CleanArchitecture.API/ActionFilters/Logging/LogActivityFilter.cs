using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.API.ActionFilters.Logging
{
    public class LogActivityFilter : IAsyncActionFilter
    {
        private readonly ILogger<LogActivityFilter> _logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Method Executed before enter the Action
            _logger.LogInformation($"Executing Action ({context.ActionDescriptor.DisplayName})");

            //Call Next Action Filter or the Action itself
            await next();

            //Method Executed Before Out the Action
            _logger.LogInformation($"Executed Action ({context.ActionDescriptor.DisplayName})");
        }
    }
}
