using BreadApp.Api.Contracts.Recipe;
using BreadApp.Application.Recipe.Commands;
using BreadApp.Application.Recipe.Queries;
using BreadApp.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    [Route("recipe")]
    public class RecipeController : BaseApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapster;

        public RecipeController(ISender mediator, IMapper mapster)
        {
            _mediator = mediator;
            _mapster = mapster;
        }


        [HttpPost("publish")]
        public async Task<IActionResult> Publish(AddRecipeRequest addRecipeRequest)
        {
            var command = _mapster.Map<AddRecipeCommand>(addRecipeRequest);

            ErrorOr<Recipe> recipe = await _mediator.Send(command);

            return recipe.Match(
                recipe => CreatedAtAction(actionName: nameof(Get), routeValues: new { id = recipe.Id }, value: _mapster.Map<RecipeResponse>(recipe)),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = _mapster.Map<GetRecipeQuery>(new GetRecipeRequest(id));

            ErrorOr<BreadApp.Domain.Entities.Recipe> bread = await _mediator.Send(query);

            return bread.Match(
                bread => Ok(_mapster.Map<RecipeResponse>(bread)),
                errors => Problem(errors)
            );
        }



    }
}