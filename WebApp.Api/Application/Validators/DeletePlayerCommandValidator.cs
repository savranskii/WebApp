using FluentValidation;
using WebApp.Api.Application.Handlers;

namespace WebApp.Api.Application.Validators;

public class DeletePlayerCommandValidator : AbstractValidator<DeletePlayerCommand>
{
    public DeletePlayerCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}
