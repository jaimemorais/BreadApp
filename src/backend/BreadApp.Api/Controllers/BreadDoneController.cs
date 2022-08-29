using BreadApp.Api.Contracts.BreadDone;
using BreadApp.Application.BreadDone.Commands;
using BreadApp.Application.BreadDone.Queries;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    [Route("breadDone")]
    public class BreadDoneController : BaseApiController
    {

        private readonly ILogger<BreadDoneController> _logger;
        private readonly ISender _mediator;
        private readonly IMapper _mapster;


        public BreadDoneController(ILogger<BreadDoneController> logger, ISender mediator, IMapper mapster)
        {
            _logger = logger;
            _mediator = mediator;
            _mapster = mapster;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(AddBreadDoneRequest addBreadDoneRequest)
        {
            var command = _mapster.Map<AddBreadDoneCommand>(addBreadDoneRequest);

            ErrorOr<BreadApp.Domain.Entities.BreadDone> breadDone = await _mediator.Send(command);

            return breadDone.Match(
                breadDone => CreatedAtAction(actionName: nameof(Get), routeValues: new { id = breadDone.Id }, value: _mapster.Map<BreadDoneResponse>(breadDone)),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = _mapster.Map<GetBreadDoneQuery>(new GetBreadDoneRequest(id));

            ErrorOr<BreadApp.Domain.Entities.BreadDone> bread = await _mediator.Send(query);

            return bread.Match(
                bread => Ok(_mapster.Map<BreadDoneResponse>(bread)),
                errors => Problem(errors)
            );
        }



    }
}