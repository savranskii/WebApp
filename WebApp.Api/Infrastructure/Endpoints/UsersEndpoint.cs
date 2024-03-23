using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Application.Handlers;
using WebApp.Api.Application.Models;
using WebApp.Domain.UserAggregate.Entities;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Infrastructure.Endpoints;

public class UsersEndpoint
{
    public static async Task<Results<Ok<User>, NotFound>> GetAsync(
        [FromRoute] long id,
        [FromServices] IMediator mediator,
        [FromServices] ILogger<UsersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute get by id user");

        var user = await mediator.Send(new GetUserQuery(id));

        return user is null ? TypedResults.NotFound() : TypedResults.Ok(user);
    }

    public static async Task<Ok<IEnumerable<User>>> GetAllAsync(
        [FromServices] IMediator mediator,
        [FromServices] ILogger<UsersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute get all user");

        var users = await mediator.Send(new GetUsersQuery());

        return TypedResults.Ok(users);
    }

    public static async Task<Ok<User>> CreateAsync(
        [FromBody] CreateUserRequest data,
        [FromServices] IMediator mediator,
        [FromServices] ILogger<UsersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute create user");

        var user = await mediator.Send(new CreateUserCommand(data));

        return TypedResults.Ok(user);
    }

    public static async Task<NoContent> UpdateAsync(
        [FromBody] UpdateUserRequest data,
        [FromServices] IMediator mediator,
        [FromServices] ILogger<UsersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute update user");

        await mediator.Send(new UpdateUserCommand(data));

        return TypedResults.NoContent();
    }

    public static async Task<NoContent> DeleteAsync(
        [FromRoute] long id,
        [FromServices] IMediator mediator,
        [FromServices] ILogger<UsersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute delete user");

        await mediator.Send(new DeleteUserCommand(id));

        return TypedResults.NoContent();
    }
}
