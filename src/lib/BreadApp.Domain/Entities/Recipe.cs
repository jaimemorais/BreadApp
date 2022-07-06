using BreadApp.Domain.Base;
using BreadApp.Domain.ValueObjects;
using System.Collections.Generic;

namespace BreadApp.Domain.Entities
{
    public class Recipe : Entity
    {
        public string Name { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }


        // TODO Domain Events

    }
}
