using BreadApp.Domain.ValueObjects;
using FluentAssertions;

namespace DomainTests
{
    public class ValueObjectTests
    {
        [Fact]
        public void Two_Different_ValueObjects_Should_Not_Be_Equal()
        {
            Measure measure1 = new("g", 100);
            Measure measure2 = new("g", 200);

            measure1.Should().NotBe(measure2);
        }

        [Fact]
        public void Two_Equal_ValueObjects_Should_Be_Equal()
        {
            RecipeIngredient recipeIngredient1 = new("butter", new Measure("g", 100));
            RecipeIngredient recipeIngredient2 = new("butter", new Measure("g", 100));

            recipeIngredient1.Should().Be(recipeIngredient2);
        }

    }
}