using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadApp.Infrastructure.Persistence
{
    public class RecipeRepository : IRecipeRepository
    {

        // TODO temporalily in memory
        private static readonly List<Recipe> _recipeList = new();


        public void Add(Recipe recipe)
        {
            _recipeList.Add(recipe);
        }

        public Recipe GetRecipeById(Guid id)
        {
            return _recipeList.SingleOrDefault(b => b.Id.Equals(id));
        }
    }
}
