using BreadApp.Domain.Base;
using BreadApp.Domain.ValueObjects;
using System.Collections.Generic;

namespace BreadApp.Domain.Entities
{
    public class Recipe : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<string> Tags { get; set; }

    }
}
