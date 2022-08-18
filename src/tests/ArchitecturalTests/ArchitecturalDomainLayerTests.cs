using BreadApp.Domain.Base;
using NetArchTest.Rules;

namespace ArchitecturalTests
{
    public class ArchitecturalDomainLayerTests
    {


        [Fact]
        public void Domain_Layer_Should_Not_Have_Dependency_On_Other_Projects()
        {
            // Arrange            
            var domainAssembly = typeof(BreadApp.Domain.BreadAppDomainDiExtension).Assembly;

            var projectsNotAllowed = new string[]
            {
                ArchTestsCommon.Infrastructure_Namespace,
                ArchTestsCommon.Application_Namespace
            };


            // Act
            var result = Types.InAssembly(domainAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(projectsNotAllowed)
                .GetResult();


            // Assert
            Assert.True(result.IsSuccessful, ArchTestsCommon.GetFailingTypes(result));
        }



        [Fact]
        public void ValueObjects_Should_Be_Immutable()
        {
            // Arrange 
            var domainAssembly = typeof(BreadApp.Domain.BreadAppDomainDiExtension).Assembly;

            // Act
            var result = Types.InAssembly(domainAssembly)
                .That()
                .Inherit(typeof(ValueObject))
                .Should()
                .BeImmutable()
                .GetResult();

            // Assert
            Assert.True(result.IsSuccessful, ArchTestsCommon.GetFailingTypes(result));
        }



    }
}