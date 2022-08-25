using BreadApp.Domain.ValueObjects;
using FluentAssertions;

namespace DomainTests
{
    public class ValueObjectTests
    {
        [Fact]
        public void Two_Different_ValueObjects_Should_Not_Be_The_Same()
        {
            Ingredient ingredient1 = new("milk", "100 ml");
            Ingredient ingredient2 = new("milk", "200 ml");

            ingredient1.Should().NotBeEquivalentTo(ingredient2);
        }

        [Fact]
        public void Two_Equal_ValueObjects_Should_Be_The_Same()
        {
            Ingredient ingredient1 = new("butter", "100 g");
            Ingredient ingredient2 = new("butter", "100 g");

            ingredient1.Should().BeEquivalentTo(ingredient2);
        }

    }
}