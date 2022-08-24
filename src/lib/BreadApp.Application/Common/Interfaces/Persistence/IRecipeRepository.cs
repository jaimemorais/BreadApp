using System;

namespace BreadApp.Application.Common.Interfaces.Persistence
{
    public interface IRecipeRepository
    {
        BreadApp.Domain.Entities.Recipe GetRecipeById(Guid id);

        void Add(BreadApp.Domain.Entities.Recipe recipe);

    }
}
