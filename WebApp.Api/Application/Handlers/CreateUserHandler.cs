using FluentValidation;
using MediatR;
using WebApp.Api.Application.Models;
using WebApp.Api.Application.Validators;
using WebApp.Domain.UserAggregate.Entities;
using WebApp.Domain.UserAggregate.Repositories;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record CreateUserCommand(CreateUserRequest Data) : IRequest<User>;

public class CreateUserHandler(IUserRepository repo, ILogger<CreateUserHandler> logger)
    : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _repo = repo;
    private readonly ILogger<CreateUserHandler> _logger = logger;

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogCategory.CommandHandler, "Validating request");
        new CreateUserCommandValidator().ValidateAndThrow(request);

        var user = new User(
            request.Data.Email,
            new(
                FirstName: request.Data.FirstName,
                LastName: request.Data.LastName
            ),
            new(
                Street: request.Data.Street,
                City: request.Data.City,
                Country: request.Data.Country,
                ZipCode: request.Data.ZipCode
            ));

        _logger.LogInformation(LogCategory.CommandHandler, "Creating user");

        _repo.Create(user);
        await _repo.UnitOfWork.SaveEntitiesAsync();

        _logger.LogInformation(LogCategory.CommandHandler, "User created");

        return user;
    }
}
