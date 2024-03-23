using WebApp.Api.Application.Constants;
using WebApp.Api.Infrastructure.Endpoints;

namespace WebApp.Api.Extensions;

public static class EndpointConfiguration
{
    public static void MapUsersEndpoints(this WebApplication app)
    {
        app.MapGroup("/api/v1/users")
            .MapUsersApi()
            .RequireRateLimiting(RateLimitPolicy.FixedPolicy)
            .WithOpenApi()
            .WithTags("Users")
            .AllowAnonymous();
    }

    public static RouteGroupBuilder MapUsersApi(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:long}", UsersEndpoint.GetAsync).WithDescription("Get user by ID");
        group.MapGet("/", UsersEndpoint.GetAllAsync).WithDescription("Retrieve all users");
        group.MapPost("/", UsersEndpoint.CreateAsync).WithDescription("Create new user");
        group.MapPut("/", UsersEndpoint.UpdateAsync).WithDescription("Update existing user");
        group.MapDelete("/{id:long}", UsersEndpoint.DeleteAsync).WithDescription("Delete user by ID");

        return group;
    }
}
