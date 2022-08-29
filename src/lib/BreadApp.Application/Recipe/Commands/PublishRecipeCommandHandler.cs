using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Recipe.Commands
{
    public class PublishRecipeCommandHandler : IRequestHandler<PublishRecipeCommand, ErrorOr<Domain.Entities.Recipe>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;

        public PublishRecipeCommandHandler(IUserRepository userRepository, IRecipeRepository recipeRepository)
        {
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<Domain.Entities.Recipe>> Handle(PublishRecipeCommand publishRecipeCommand, CancellationToken cancellationToken)
        {
            var recipe = _recipeRepository.GetRecipeByName(publishRecipeCommand.Name);
            if (recipe is not null)
            {
                return RecipeDomainErrors.DuplicateName;
            }

            var user = _userRepository.GetUserByEmail(publishRecipeCommand.UserEmail);
            if (user is null)
            {
                return UserDomainErrors.UserNotFound;
            }

            Domain.Entities.Recipe Recipe = new()
            {
                User = user,
                Name = publishRecipeCommand.Name,
                Date = publishRecipeCommand.Date,
                Instructions = publishRecipeCommand.Instructions,
                Tags = publishRecipeCommand.Tags,
                Ingredients = publishRecipeCommand.Ingredients
            };

            _recipeRepository.Add(Recipe);

            await Task.CompletedTask;

            return Recipe;

        }
    }

}
