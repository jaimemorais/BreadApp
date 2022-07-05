using BreadApp.Domain.ValueObject;
using System.Collections.Generic;

namespace BreadApp.Domain.Entity
{
    public class Recipe
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }


        // TODO Domain Events

    }
}
