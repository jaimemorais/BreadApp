﻿using FluentValidation;

namespace BreadApp.Application.BreadDone.Commands
{
    public class AddBreadDoneCommandValidator : AbstractValidator<AddBreadDoneCommand>
    {
        public AddBreadDoneCommandValidator()
        {
            RuleFor(c => c.UserEmail).NotEmpty();
            RuleFor(c => c.RecipeId).NotEmpty();
            RuleFor(c => c.Date).NotEmpty();
        }
    }
}
