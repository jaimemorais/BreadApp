using BreadApp.Api.Contracts.Image;
using BreadApp.Application.Image.Commands;
using BreadApp.Application.Image.Queries;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    [Route("image")]
    public class ImageController : BaseApiController
    {

        private readonly ILogger<ImageController> _logger;
        private readonly ISender _mediator;
        private readonly IMapper _mapster;


        public ImageController(ILogger<ImageController> logger, ISender mediator, IMapper mapster)
        {
            _logger = logger;
            _mediator = mediator;
            _mapster = mapster;
        }


        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile imageFile)
        {
            var command = _mapster.Map<UploadImageCommand>(new UploadImageRequest(imageFile));

            ErrorOr<BreadApp.Domain.Entities.Image> image = await _mediator.Send(command);

            return image.Match(
                image => CreatedAtAction(actionName: nameof(Get), routeValues: new { id = image.Id }, value: _mapster.Map<ImageResponse>(image)),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = _mapster.Map<GetImageQuery>(new GetImageRequest(id));

            ErrorOr<BreadApp.Domain.Entities.Image> image = await _mediator.Send(query);

            return image.Match(
                image => Ok(_mapster.Map<ImageResponse>(image)),
                errors => Problem(errors)
            );
        }



    }
}