using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Recipe.Queries
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, ErrorOr<Domain.Entities.Recipe>>
    {

        private readonly IRecipeRepository _recipeRepository;

        public GetRecipeQueryHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<BreadApp.Domain.Entities.Recipe>> Handle(GetRecipeQuery getBreadQuery, CancellationToken cancellationToken)
        {

            if (_recipeRepository.GetRecipeById(getBreadQuery.Id) is not BreadApp.Domain.Entities.Recipe recipe)
            {
                return RecipeDomainErrors.RecipeNotFound;
            }


            await Task.CompletedTask;

            return recipe;
        }
    }

}
