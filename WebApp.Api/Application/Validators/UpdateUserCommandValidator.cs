using FluentValidation;
using WebApp.Api.Application.Handlers;

namespace WebApp.Api.Application.Commands;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.Data.Id).NotEmpty();
        RuleFor(command => command.Data.FirstName).NotEmpty().MinimumLength(2).MaximumLength(20);
        RuleFor(command => command.Data.LastName).NotEmpty().MinimumLength(2).MaximumLength(20);
        RuleFor(command => command.Data.Street).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(command => command.Data.City).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(command => command.Data.Country).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(command => command.Data.ZipCode).NotEmpty().MinimumLength(5).MaximumLength(10);
    }
}
