using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Application.Recipe.Commands;
using BreadApp.Domain.Entities;
using BreadApp.Domain.Errors;
using BreadApp.Domain.ValueObjects;
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

            PublishRecipeCommand publishRecipeCommand = new(
                "jaimemorais@gmail.com",
                "My Recipe",
                DateTime.Now,
                "Mix it all",
                new List<Ingredient>()
                {
                    new Ingredient("Flour", "100g")
                },
                null);


            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(publishRecipeCommand.UserEmail))
                .Returns<User>(null);

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();

            var commandHandler = new PublishRecipeCommandHandler(userRepositoryMock.Object, recipeRepositoryMock.Object);


            // Assert

            var commandReturn = await commandHandler.Handle(publishRecipeCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeTrue();
            commandReturn.Errors.Count.Should().BeGreaterThan(0, "have errors");
            commandReturn.Errors.Should().Contain(UserDomainErrors.UserNotFound, $"should return the {nameof(UserDomainErrors.UserNotFound)} domain error");

        }


        [Fact]
        public async Task PublishRecipeCommand_Should_Fail_If_Name_Is_Duplicate()
        {
            // Arrange

            const string MY_RECIPE_NAME = "My Recipe";

            PublishRecipeCommand publishRecipeCommand = new(
                "jaimemorais@gmail.com",
                MY_RECIPE_NAME,
                DateTime.Now,
                "Mix it all",
                new List<Ingredient>()
                {
                    new Ingredient("Flour", "100g")
                },
                null);


            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(publishRecipeCommand.UserEmail))
                .Returns(new User() { Name = "My User" });

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();
            recipeRepositoryMock
                .Setup(e => e.GetRecipeByName(publishRecipeCommand.Name))
                .Returns(new Recipe() { Name = MY_RECIPE_NAME });

            var commandHandler = new PublishRecipeCommandHandler(userRepositoryMock.Object, recipeRepositoryMock.Object);


            // Assert

            var commandReturn = await commandHandler.Handle(publishRecipeCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeTrue();
            commandReturn.Errors.Count.Should().BeGreaterThan(0, "have errors");
            commandReturn.Errors.Should().Contain(RecipeDomainErrors.DuplicateName, $"should return the {nameof(RecipeDomainErrors.DuplicateName)} domain error");

        }


        [Fact]
        public async Task PublishRecipeCommand_Success()
        {
            // Arrange

            const string MY_RECIPE_NAME = "My Recipe";

            PublishRecipeCommand publishRecipeCommand = new(
                "jaimemorais@gmail.com",
                MY_RECIPE_NAME,
                DateTime.Now,
                "Mix it all",
                new List<Ingredient>()
                {
                    new Ingredient("Flour", "100g")
                },
                null);


            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(publishRecipeCommand.UserEmail))
                .Returns(new User() { Name = "My User" });

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();

            var commandHandler = new PublishRecipeCommandHandler(userRepositoryMock.Object, recipeRepositoryMock.Object);


            // Assert

            var commandReturn = await commandHandler.Handle(publishRecipeCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeFalse();
            commandReturn.Value.Should().NotBeNull();
            commandReturn.Value.Name.Should().Be(MY_RECIPE_NAME);

        }



    }
}