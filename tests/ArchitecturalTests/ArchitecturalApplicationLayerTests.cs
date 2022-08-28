using NetArchTest.Rules;

namespace ArchitecturalTests
{
    public class ArchitecturalApplicationLayerTests
    {
        [Fact]
        public void Handlers_Should_Have_Dependency_On_Domain()
        {
            // Arrange
            var applicationAssembly = typeof(BreadApp.Application.BreadAppApplicationDiExtension).Assembly;

            // Act
            var result = Types.InAssembly(applicationAssembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(ArchTestsCommon.Domain_Namespace)
                .GetResult();

            // Assert
            Assert.True(result.IsSuccessful, ArchTestsCommon.GetFailingTypes(result));
        }



    }
}