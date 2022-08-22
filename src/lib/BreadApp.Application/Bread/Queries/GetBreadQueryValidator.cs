using FluentValidation;

namespace BreadApp.Application.Bread.Queries;

public class GetBreadQueryValidator : AbstractValidator<GetBreadQuery>
{
    public GetBreadQueryValidator()
    {
        RuleFor(q => q.Id).NotEmpty();

    }

}

