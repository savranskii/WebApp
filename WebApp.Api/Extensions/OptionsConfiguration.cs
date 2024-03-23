using WebApp.Api.Application.Constants;
using WebApp.Infrastructure.Models.Options;

namespace WebApp.Api.Extensions;

public static class OptionsConfiguration
{
    public static void ConfigureOptions(this IServiceCollection services)
    {
        services.AddOptions<RateLimitOptions>().BindConfiguration(OptionsKey.RateLimit).ValidateDataAnnotations().ValidateOnStart();
        services.AddOptions<ConnectionOptions>().BindConfiguration(OptionsKey.Connection).ValidateDataAnnotations().ValidateOnStart();
    }
}
