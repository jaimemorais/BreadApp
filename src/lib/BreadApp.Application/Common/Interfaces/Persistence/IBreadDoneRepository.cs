using System;

namespace BreadApp.Application.Common.Interfaces.Persistence
{
    public interface IBreadDoneRepository
    {
        BreadApp.Domain.Entities.BreadDone GetBreadDoneById(Guid id);


        void Add(BreadApp.Domain.Entities.BreadDone breadDone);

    }
}
