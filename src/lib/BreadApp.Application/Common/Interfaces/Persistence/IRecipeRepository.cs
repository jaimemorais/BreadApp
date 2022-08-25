using System;

namespace BreadApp.Application.Common.Interfaces.Persistence
{
    public interface IRecipeRepository
    {
        Domain.Entities.Recipe GetRecipeById(Guid id);

        Domain.Entities.Recipe GetRecipeByName(string name);

        void Add(Domain.Entities.Recipe recipe);

    }
}
