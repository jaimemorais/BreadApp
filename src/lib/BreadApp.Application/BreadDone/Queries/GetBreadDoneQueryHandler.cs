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

        private readonly IBreadDoneRepository _breadDoneRepository;

        public GetBreadDoneQueryHandler(IBreadDoneRepository breadRepository)
        {
            _breadDoneRepository = breadRepository;
        }

        public async Task<ErrorOr<BreadApp.Domain.Entities.BreadDone>> Handle(GetBreadDoneQuery getBreadQuery, CancellationToken cancellationToken)
        {

            if (_breadDoneRepository.GetBreadDoneById(getBreadQuery.Id) is not BreadApp.Domain.Entities.BreadDone breadDone)
            {
                return BreadDoneDomainErrors.NotFound;
            }


            await Task.CompletedTask;

            return breadDone;
        }
    }

}
