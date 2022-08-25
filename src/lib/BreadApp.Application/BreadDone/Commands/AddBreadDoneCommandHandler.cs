using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.BreadDone.Commands
{
    public class AddBreadDoneCommandHandler : IRequestHandler<AddRecipeCommand, ErrorOr<Domain.Entities.BreadDone>>
    {
        private readonly IBreadDoneRepository _breadDoneRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRecipeRepository _recipeRepository;

        public AddBreadDoneCommandHandler(IBreadDoneRepository breadDoneRepository, IUserRepository userRepository, IRecipeRepository recipeRepository)
        {
            _breadDoneRepository = breadDoneRepository;
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<Domain.Entities.BreadDone>> Handle(AddRecipeCommand addBreadDoneCommand, CancellationToken cancellationToken)
        {
            var recipe = _recipeRepository.GetRecipeById(addBreadDoneCommand.RecipeId);
            if (recipe is null)
            {
                return BreadDoneDomainErrors.RecipeNotFound;
            }

            var user = _userRepository.GetUserByEmail(addBreadDoneCommand.UserEmail);
            if (user is null)
            {
                return BreadDoneDomainErrors.UserNotFound;
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
