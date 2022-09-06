using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BreadApp.Application.Image.Commands
{
    public record UploadImageCommand(IFormFile ImageFile) : IRequest<ErrorOr<Domain.Entities.Image>>;

}
