using System;

namespace BreadApp.Application.Common.Interfaces.Persistence
{
    public interface IBreadRepository
    {
        BreadApp.Domain.Entities.Bread GetBreadById(Guid id);

        BreadApp.Domain.Entities.Bread GetBreadByName(string name);

        void Add(BreadApp.Domain.Entities.Bread bread);

    }
}
