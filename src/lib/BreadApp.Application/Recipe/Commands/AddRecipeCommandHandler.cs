using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Application.Common.Interfaces.Storage;
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
        private readonly IImageStorageService _imageStorageService;

        public AddRecipeCommandHandler(IUserRepository userRepository, IRecipeRepository recipeRepository, IImageStorageService imageStorageService)
        {
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
            _imageStorageService = imageStorageService;
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


            // TODO upload image
            // string imageBlobId = await _imageStorageService.StoreImage();

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
