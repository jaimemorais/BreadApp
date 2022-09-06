using FluentValidation;

namespace BreadApp.Application.Image.Commands
{
    public class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
    {
        public UploadImageCommandValidator()
        {
            RuleFor(u => u.ImageFile.Length).GreaterThan(0);
        }
    }

}
