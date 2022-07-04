using BreadApp.Domain.Base;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchitecturalTests
{
    public class DomainLayerTests
    {
        [Fact]
        public void ValueObjects_Should_Be_Immutable()
        {
            var result = Types.InAssembly(Assembly.Load("BreadApp.Domain"))
                .That()
                .Inherit(typeof(ValueObject))
                .Should()
                .BeImmutable()
                .GetResult();

            Assert.True(result.IsSuccessful, ArchTestsUtils.GetFailingTypes(result));
        }



    }
}