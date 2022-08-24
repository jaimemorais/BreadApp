using FluentValidation;

namespace BreadApp.Application.BreadDone.Queries
{

    public class GetBreadDoneQueryValidator : AbstractValidator<GetBreadDoneQuery>
    {
        public GetBreadDoneQueryValidator()
        {
            RuleFor(q => q.Id).NotEmpty();

        }

    }
}