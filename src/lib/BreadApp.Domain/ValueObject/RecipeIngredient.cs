namespace BreadApp.Domain.ValueObject
{
    public readonly struct RecipeIngredient
    {
        public RecipeIngredient(Ingredient ingredient, Measure measure)
        {
            Ingredient = ingredient;
            Measure = measure;
        }

        public Ingredient Ingredient { get; }

        public Measure Measure { get; }

    }
}
