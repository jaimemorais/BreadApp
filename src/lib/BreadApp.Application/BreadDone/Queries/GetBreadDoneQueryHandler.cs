using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.BreadDone.Queries
{
    public class GetBreadDoneQueryHandler : IRequestHandler<GetBreadDoneQuery, ErrorOr<Domain.Entities.BreadDone>>
    {

        private readonly IBreadDoneRepository _breadRepository;

        public GetBreadDoneQueryHandler(IBreadDoneRepository breadRepository)
        {
            _breadRepository = breadRepository;
        }

        public async Task<ErrorOr<BreadApp.Domain.Entities.BreadDone>> Handle(GetBreadDoneQuery getBreadQuery, CancellationToken cancellationToken)
        {

            if (_breadRepository.GetBreadDoneById(getBreadQuery.Id) is not BreadApp.Domain.Entities.BreadDone bread)
            {
                return BreadDoneDomainErrors.NotFound;
            }


            await Task.CompletedTask;

            return bread;
        }
    }

}
