using FluentValidation;
using MediatR;
using WebApp.Api.Application.Validators;
using WebApp.Domain.UserAggregate.Repositories;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record DeleteUserCommand(long Id) : IRequest;

public class DeleteUserHandler(IUserRepository repo, ILogger<DeleteUserHandler> logger)
    : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repo = repo;
    private readonly ILogger<DeleteUserHandler> _logger = logger;

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogCategory.CommandHandler, "Validating request");
        new DeleteUserCommandValidator().ValidateAndThrow(request);

        _logger.LogInformation(LogCategory.CommandHandler, "Deleting user");

        await _repo.DeleteAsync(request.Id);
        await _repo.UnitOfWork.SaveEntitiesAsync();

        _logger.LogInformation(LogCategory.CommandHandler, "User deleted");
    }
}
