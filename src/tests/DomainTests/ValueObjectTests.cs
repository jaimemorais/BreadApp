using BreadApp.Domain.ValueObjects;
using FluentAssertions;

namespace DomainTests
{
    public class ValueObjectTests
    {
        [Fact]
        public void Two_Different_ValueObjects_Should_Not_Be_The_Same()
        {
            Measure measure1 = new(Unit.Gram, 100);
            Measure measure2 = new(Unit.Gram, 200);

            measure1.Should().NotBe(measure2);
        }

        [Fact]
        public void Two_Equal_ValueObjects_Should_Be_The_Same()
        {
            Ingredient ingredient1 = new("butter", new Measure(Unit.Gram, 100));
            Ingredient ingredient2 = new("butter", new Measure(Unit.Gram, 100));

            ingredient1.Should().Be(ingredient2);
        }

    }
}