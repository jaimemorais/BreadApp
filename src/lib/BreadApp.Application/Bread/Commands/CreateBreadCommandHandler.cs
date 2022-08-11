using BreadApp.Application.Interfaces.Persistence;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Bread.Commands
{
    public class CreateBreadCommandHandler : IRequestHandler<CreateBreadCommand, ErrorOr<Domain.Entities.Bread>>
    {
        private readonly IBreadRepository _breadRepository;

        public CreateBreadCommandHandler(IBreadRepository breadRepository)
        {
            _breadRepository = breadRepository;
        }

        public async Task<ErrorOr<Domain.Entities.Bread>> Handle(CreateBreadCommand createBreadCommand, CancellationToken cancellationToken)
        {

            if (_breadRepository.GetBreadByName(createBreadCommand.Name) is not null)
            {
                return BreadErrors.DuplicateName;
            }

            Domain.Entities.Bread bread = new()
            {
                Name = createBreadCommand.Name,
                Description = createBreadCommand.Description,
                Tags = createBreadCommand.Tags
            };

            _breadRepository.Add(bread);


            await Task.CompletedTask;

            return bread;

        }
    }

}
