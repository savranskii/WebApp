using WebApp.Api.Infrastructure.ExceptionHandlers;

namespace WebApp.Api.Extensions;

public static class ExceptionHandlerConfiguration
{
    public static void ConfigureExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<DefaultExceptionHandler>();
    }
}
