using BreadApp.Domain.Base;
using System.Collections.Generic;

namespace BreadApp.Domain.ValueObjects
{
    public class Ingredient : ValueObject
    {
        public Ingredient(string ingredientName, string measure)
        {
            IngredientName = ingredientName;
            Measure = measure;
        }

        public string IngredientName { get; private set; }

        public string Measure { get; private set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IngredientName;
            yield return Measure;
        }
    }
}
