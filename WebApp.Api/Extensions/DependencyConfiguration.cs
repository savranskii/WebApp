﻿using Microsoft.EntityFrameworkCore;
using WebApp.Api.Application.Constants;
using WebApp.Domain.PlayerAggregate.Repositories;
using WebApp.Infrastructure.Contexts;
using WebApp.Infrastructure.Models.Options;
using WebApp.Infrastructure.Repositories;

namespace WebApp.Api.Extensions;

public static class DependencyConfiguration
{
    public static void ConfigureDependencies(this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionOptions = new ConnectionOptions();
        configuration.GetSection(OptionsKey.Connection).Bind(connectionOptions);

        services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionOptions.PostgresSqlServer));
        services.AddScoped<IPlayerRepository, PlayerRepository>();
    }
}
