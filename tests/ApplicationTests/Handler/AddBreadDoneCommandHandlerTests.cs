using BreadApp.Application.BreadDone.Commands;
using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using BreadApp.Domain.Errors;
using FluentAssertions;
using Moq.AutoMock;

namespace ApplicationTests.Handler
{
    public class AddBreadDoneCommandHandlerTests
    {

        [Fact]
        public async Task AddBreadDoneCommand_Should_Fail_If_User_Do_Not_Exist()
        {
            // Arrange

            var recipeMock = new Recipe()
            {
                Id = Guid.NewGuid()
            };

            AddBreadDoneCommand addBreadDoneCommand = new(
                DateTime.Now,
                "jaimemorais@gmail.com",
                recipeMock.Id,
                null,
                null);


            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(addBreadDoneCommand.UserEmail))
                .Returns<User>(null);

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();
            recipeRepositoryMock
                .Setup(e => e.GetRecipeById(recipeMock.Id))
                .Returns(recipeMock);

            var commandHandler = autoMocker.CreateInstance<AddBreadDoneCommandHandler>();



            // Assert

            var commandReturn = await commandHandler.Handle(addBreadDoneCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeTrue();
            commandReturn.Errors.Count.Should().BeGreaterThan(0, "have errors");
            commandReturn.Errors.Should().Contain(UserDomainErrors.UserNotFound, $"should return the {nameof(UserDomainErrors.UserNotFound)} domain error");

        }



        [Fact]
        public async Task AddBreadDoneCommand_Should_Fail_If_Recipe_Do_Not_Exist()
        {
            // Arrange

            AddBreadDoneCommand addBreadDoneCommand = new(
                DateTime.Now,
                "jaimemorais@gmail.com",
                Guid.NewGuid(),
                null,
                null);


            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(addBreadDoneCommand.UserEmail))
                .Returns(new User() { Email = addBreadDoneCommand.UserEmail });

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();
            recipeRepositoryMock
                .Setup(e => e.GetRecipeById(addBreadDoneCommand.RecipeId))
                .Returns<Recipe>(null);

            var commandHandler = autoMocker.CreateInstance<AddBreadDoneCommandHandler>();



            // Assert

            var commandReturn = await commandHandler.Handle(addBreadDoneCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeTrue();
            commandReturn.Errors.Count.Should().BeGreaterThan(0, "have errors");
            commandReturn.Errors.Should().Contain(RecipeDomainErrors.RecipeNotFound, $"should return the {nameof(RecipeDomainErrors.RecipeNotFound)} domain error");

        }


        [Fact]
        public async Task AddBreadDoneCommand_Success()
        {
            // Arrange

            var recipeMock = new Recipe()
            {
                Id = Guid.NewGuid()
            };

            var userMock = new User()
            {
                Email = "jaimemorais@gmail.com"
            };


            AddBreadDoneCommand addBreadDoneCommand = new(
                DateTime.Now,
                userMock.Email,
                recipeMock.Id,
                null,
                null);


            var autoMocker = new AutoMocker();

            var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            userRepositoryMock
                .Setup(e => e.GetUserByEmail(addBreadDoneCommand.UserEmail))
                .Returns(userMock);

            var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();
            recipeRepositoryMock
                .Setup(e => e.GetRecipeById(addBreadDoneCommand.RecipeId))
                .Returns(recipeMock);

            var commandHandler = autoMocker.CreateInstance<AddBreadDoneCommandHandler>();



            // Assert

            var commandReturn = await commandHandler.Handle(addBreadDoneCommand, new CancellationToken());


            // Act

            commandReturn.IsError.Should().BeFalse();
            commandReturn.Value.Should().NotBeNull();
            commandReturn.Value.Recipe.Id.Should().Be(recipeMock.Id);
        }

    }
}