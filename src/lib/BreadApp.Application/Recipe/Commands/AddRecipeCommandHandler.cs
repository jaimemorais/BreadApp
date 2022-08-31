using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Recipe.Commands
{
    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, ErrorOr<Domain.Entities.Recipe>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;

        public AddRecipeCommandHandler(IUserRepository userRepository, IRecipeRepository recipeRepository)
        {
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<Domain.Entities.Recipe>> Handle(AddRecipeCommand addRecipeCommand, CancellationToken cancellationToken)
        {
            var recipe = _recipeRepository.GetRecipeByName(addRecipeCommand.Name);
            if (recipe is not null)
            {
                return RecipeDomainErrors.DuplicateName;
            }

            var user = _userRepository.GetUserByEmail(addRecipeCommand.UserEmail);
            if (user is null)
            {
                return UserDomainErrors.UserNotFound;
            }

            recipe = new()
            {
                User = user,
                Name = addRecipeCommand.Name,
                Date = addRecipeCommand.Date,
                Instructions = addRecipeCommand.Instructions,
                Tags = addRecipeCommand.Tags,
                Ingredients = addRecipeCommand.Ingredients,
                IsPublished = false
            };

            _recipeRepository.Add(recipe);

            await Task.CompletedTask;

            return recipe;

        }
    }

}
