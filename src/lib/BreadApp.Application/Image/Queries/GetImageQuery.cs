using ErrorOr;
using MediatR;

namespace BreadApp.Application.Image.Queries
{
    public record GetImageQuery() : IRequest<ErrorOr<Domain.Entities.Image>>;

}
