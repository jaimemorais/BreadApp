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
        public void Publish(Guid recipeId)
        {
            var recipeToUpdate = _recipeList.SingleOrDefault(r => r.Id.Equals(recipeId));
            recipeToUpdate.IsPublished = true;
        }


        public Recipe GetRecipeById(Guid id)
        {
            return _recipeList.SingleOrDefault(r => r.Id.Equals(id));
        }

        public Recipe GetRecipeByName(string name)
        {
            return _recipeList.SingleOrDefault(r => r.Name.Equals(name));
        }

    }
}
