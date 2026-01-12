using AudioProcessingService.Middleware;

namespace AudioProcessingService.Extensions;

internal static class StartUpExtensions
{
    /// <summary>
    /// Registers all applications services for dependency injection
    /// </summary>
    /// <param name="services">The service collection to add services to</param>
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddExceptionHandler<ExceptionHandler>();
    }
}