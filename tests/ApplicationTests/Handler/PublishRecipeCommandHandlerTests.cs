using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Application.Recipe.Commands;
using BreadApp.Domain.Entities;
using BreadApp.Domain.Errors;
using FluentAssertions;
using Moq.AutoMock;

namespace ApplicationTests.Handler
{
    public class PublishRecipeCommandHandlerTests
    {
        [Fact]
        public async Task PublishRecipeCommand_Should_Fail_If_User_Do_Not_Exist()
        {
            // Arrange

            var recipeId = Guid.NewGuid();

            PublishRecipeCommand PublishRecipeCommand = new(
                "jaimemorais@gmail.com",
                recipeId);


            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(PublishRecipeCommand.UserEmail))
                .Returns<User>(null);

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();
            recipeRepositoryMock
                .Setup(e => e.GetRecipeById(recipeId))
                .Returns(new Recipe() { Id = recipeId, Name = "Test Recipe" });

            var commandHandler = autoMocker.CreateInstance<PublishRecipeCommandHandler>();



            // Assert

            var commandReturn = await commandHandler.Handle(PublishRecipeCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeTrue();
            commandReturn.Errors.Count.Should().BeGreaterThan(0, "have errors");
            commandReturn.Errors.Should().Contain(UserDomainErrors.UserNotFound, $"should return the {nameof(UserDomainErrors.UserNotFound)} domain error");
        }


        [Fact]
        public async Task PublishRecipeCommand_Should_Fail_If_Recipe_Do_Not_Exist()
        {
            // Arrange

            var recipeId = Guid.NewGuid();

            PublishRecipeCommand PublishRecipeCommand = new(
                "jaimemorais@gmail.com",
                recipeId);

            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(PublishRecipeCommand.UserEmail))
                .Returns(new User() { Name = "My User" });

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();
            recipeRepositoryMock
                .Setup(e => e.GetRecipeById(recipeId))
                .Returns<Recipe>(null);

            var commandHandler = autoMocker.CreateInstance<PublishRecipeCommandHandler>();


            // Assert

            var commandReturn = await commandHandler.Handle(PublishRecipeCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeTrue();
            commandReturn.Errors.Count.Should().BeGreaterThan(0, "have errors");
            commandReturn.Errors.Should().Contain(RecipeDomainErrors.RecipeNotFound, $"should return the {nameof(RecipeDomainErrors.RecipeNotFound)} domain error");

        }


        [Fact]
        public async Task PublishRecipeCommand_Success()
        {
            // Arrange

            var recipeId = Guid.NewGuid();

            PublishRecipeCommand PublishRecipeCommand = new(
                "jaimemorais@gmail.com",
                recipeId);


            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(PublishRecipeCommand.UserEmail))
                .Returns(new User() { Name = "My User" });

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();
            recipeRepositoryMock
                .Setup(e => e.GetRecipeById(recipeId))
                .Returns(new Recipe() { Id = recipeId, Name = "Test Recipe" });


            var commandHandler = autoMocker.CreateInstance<PublishRecipeCommandHandler>();


            // Assert

            var commandReturn = await commandHandler.Handle(PublishRecipeCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeFalse();
            commandReturn.Value.Should().NotBeNull();
            commandReturn.Value.Id.Should().Be(recipeId);

        }



    }
}