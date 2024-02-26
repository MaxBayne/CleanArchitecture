using System.Diagnostics;

namespace CleanArchitecture.API.Middlewares;

/// <summary>
/// Measure the Time that Request Token When Enter as Request and Out as Response
/// </summary>
public class ProfilingMiddleware
{
    private readonly ILogger<ProfilingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ProfilingMiddleware(ILogger<ProfilingMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        var stopWatch = new Stopwatch();

        stopWatch.Start();

        //Go Execute the Next Middleware inside Pipeline and wait it until finished
        await _next(context);

        stopWatch.Stop();

        _logger.LogInformation($"Request ({context.Request.Path}) Took {stopWatch.ElapsedMilliseconds} ms");
    }
}