using WebApp.Api.Application.Constants;
using WebApp.Infrastructure.Models.Options;

namespace WebApp.Api.Extensions;

public static class CorsConfiguration
{
    public const string UiCors = "_UI";
    
    public static void ConfigureCors(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddCors(options => options.AddPolicy(name: UiCors, policy =>
        {
            // configuration
            var corsOptions = new CorsOptions();
            configuration.GetSection(OptionsKey.Cors).Bind(corsOptions);
            
            policy
                .WithOrigins(corsOptions.Origins)
                .AllowAnyHeader()
                .AllowAnyMethod();
        }));
    }
}
