using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using WebApp.Api.Application.Constants;
using WebApp.Infrastructure.Models.Options;

namespace WebApp.Api.Extensions;

public static class RateLimitConfiguration
{
    public static void ConfigureRateLimit(this IServiceCollection services, ConfigurationManager configuration)
    {
        var rateLimitOptions = new RateLimitOptions();
        configuration.GetSection(OptionsKey.RateLimit).Bind(rateLimitOptions);

        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            options.AddFixedWindowLimiter(policyName: RateLimitPolicy.FixedPolicy, options =>
            {
                options.PermitLimit = rateLimitOptions.PermitLimit;
                options.Window = TimeSpan.FromSeconds(rateLimitOptions.Window);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = rateLimitOptions.QueueLimit;
            });
        });
    }
}
