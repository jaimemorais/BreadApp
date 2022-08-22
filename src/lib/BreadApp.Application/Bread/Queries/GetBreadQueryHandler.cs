using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Bread.Queries
{
    public class GetBreadQueryHandler : IRequestHandler<GetBreadQuery, ErrorOr<Domain.Entities.Bread>>
    {

        private readonly IBreadRepository _breadRepository;

        public GetBreadQueryHandler(IBreadRepository breadRepository)
        {
            _breadRepository = breadRepository;
        }

        public async Task<ErrorOr<BreadApp.Domain.Entities.Bread>> Handle(GetBreadQuery getBreadQuery, CancellationToken cancellationToken)
        {

            if (_breadRepository.GetBreadById(getBreadQuery.Id) is not BreadApp.Domain.Entities.Bread bread)
            {
                return BreadDomainErrors.BreadNotFound;
            }


            await Task.CompletedTask;

            return bread;
        }
    }

}
