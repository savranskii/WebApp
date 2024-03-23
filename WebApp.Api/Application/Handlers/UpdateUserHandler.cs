using FluentValidation;
using MediatR;
using WebApp.Api.Application.Commands;
using WebApp.Api.Application.Models;
using WebApp.Domain.UserAggregate.Repositories;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record UpdateUserCommand(UpdateUserRequest Data) : IRequest;

public class UpdateUserHandler(IUserRepository repo, ILogger<UpdateUserHandler> logger)
    : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _repo = repo;
    private readonly ILogger<UpdateUserHandler> _logger = logger;

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogCategory.CommandHandler, "Validating request");
        new UpdateUserCommandValidator().ValidateAndThrow(request);

        _logger.LogInformation(LogCategory.CommandHandler, "Updating user");

        var user = await _repo.GetByIdAsync(request.Data.Id) ?? throw new ArgumentException("Invalid ID");
        user.SetName(new(
            FirstName: request.Data.FirstName,
            LastName: request.Data.LastName
        ));
        user.SetAddress(new(
            Street: request.Data.Street,
            City: request.Data.City,
            Country: request.Data.Country,
            ZipCode: request.Data.ZipCode
        ));

        await _repo.UnitOfWork.SaveEntitiesAsync();

        _logger.LogInformation(LogCategory.CommandHandler, "User updated");
    }
}
