using FluentValidation;
using WebApp.Api.Application.Handlers;

namespace WebApp.Api.Application.Validators;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}
