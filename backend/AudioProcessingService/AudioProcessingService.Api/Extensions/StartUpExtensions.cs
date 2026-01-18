using AudioProcessingService.Api.Interfaces.Pipeline;
using AudioProcessingService.Api.Interfaces.Services;
using AudioProcessingService.Api.Middleware;
using AudioProcessingService.Api.Pipeline;
using AudioProcessingService.Api.Services;

namespace AudioProcessingService.Api.Extensions;

internal static class StartUpExtensions
{
    /// <summary>
    /// Registers all applications services for dependency injection
    /// </summary>
    /// <param name="services">The service collection to add services to</param>
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddExceptionHandler<ExceptionHandler>()
            .AddScoped<IAudioService, AudioService>()
            .AddScoped<IFileService, FileService>();
    }
    
    /// <summary>
    /// Registers all pipeline classes for dependency injection
    /// </summary>
    /// <param name="services">he service collection to add services to</param>
    internal static IServiceCollection AddPipelines(this IServiceCollection services)
    {
        return services
            .AddScoped<IFormatNormalizer, FormatNormalizer>()
            .AddScoped<IVolumeNormalizer, VolumeNormalizer>();
    }
}