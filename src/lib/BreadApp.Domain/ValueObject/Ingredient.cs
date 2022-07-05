namespace BreadApp.Domain.ValueObject
{
    public readonly struct Ingredient 
    {
        public Ingredient(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
