using BreadApp.Api.Contracts.Bread;
using BreadApp.Application.Bread.Commands;
using BreadApp.Application.Bread.Queries;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    [Route("bread")]
    public class BreadController : BaseApiController
    {

        private readonly ILogger<BreadController> _logger;
        private readonly ISender _mediator;
        private readonly IMapper _mapster;


        public BreadController(ILogger<BreadController> logger, ISender mediator, IMapper mapster)
        {
            _logger = logger;
            _mediator = mediator;
            _mapster = mapster;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateBreadRequest createBreadRequest)
        {
            var command = _mapster.Map<CreateBreadCommand>(createBreadRequest);

            ErrorOr<BreadApp.Domain.Entities.Bread> bread = await _mediator.Send(command);

            return bread.Match(
                bread => CreatedAtAction(actionName: nameof(GetBread), routeValues: new { id = bread.Id }, value: _mapster.Map<BreadResponse>(bread)),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBread([FromRoute] Guid id)
        {
            var query = _mapster.Map<GetBreadQuery>(new GetBreadRequest(id));

            ErrorOr<BreadApp.Domain.Entities.Bread> bread = await _mediator.Send(query);

            return bread.Match(
                bread => Ok(_mapster.Map<BreadResponse>(bread)),
                errors => Problem(errors)
            );
        }



    }
}