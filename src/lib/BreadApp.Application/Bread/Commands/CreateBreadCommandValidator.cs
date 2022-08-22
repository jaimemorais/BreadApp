using FluentValidation;

namespace BreadApp.Application.Bread.Commands
{
    public class CreateBreadCommandValidator : AbstractValidator<CreateBreadCommand>
    {
        public CreateBreadCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty().MinimumLength(10);
        }
    }
}
