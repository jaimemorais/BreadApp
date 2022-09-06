using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.BreadDone.Commands
{
    public class AddBreadDoneCommandHandler : IRequestHandler<AddBreadDoneCommand, ErrorOr<Domain.Entities.BreadDone>>
    {
        private readonly IBreadDoneRepository _breadDoneRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRecipeRepository _recipeRepository;

        public AddBreadDoneCommandHandler(IBreadDoneRepository breadDoneRepository, IUserRepository userRepository,
            IRecipeRepository recipeRepository)
        {
            _breadDoneRepository = breadDoneRepository;
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
        }


        public async Task<ErrorOr<Domain.Entities.BreadDone>> Handle(AddBreadDoneCommand addBreadDoneCommand, CancellationToken cancellationToken)
        {
            var recipe = _recipeRepository.GetRecipeById(addBreadDoneCommand.RecipeId);
            if (recipe is null)
            {
                return RecipeDomainErrors.RecipeNotFound;
            }

            var user = _userRepository.GetUserByEmail(addBreadDoneCommand.UserEmail);
            if (user is null)
            {
                return UserDomainErrors.UserNotFound;
            }

            Domain.Entities.BreadDone breadDone = new()
            {
                Date = addBreadDoneCommand.Date,
                Comments = addBreadDoneCommand.Comments,
                Tags = addBreadDoneCommand.Tags,
                User = user,
                Recipe = recipe
            };

            _breadDoneRepository.Add(breadDone);

            await Task.CompletedTask;

            return breadDone;

        }
    }

}
