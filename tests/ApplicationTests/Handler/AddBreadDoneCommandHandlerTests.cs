namespace ApplicationTests.Handler
{
    public class AddBreadDoneCommandHandlerTests
    {
        [Fact]
        public async Task AddBreadDoneCommand_Should_Fail_If_User_Do_Not_Exist()
        {
            // Arrange

            //AddBreadDoneCommand AddBreadDoneCommand = new(
            //    DateTime.Now,
            //    "Mix it all",
            //    new List<Ingredient>()
            //    {
            //        new Ingredient("Flour", "100g")
            //    },
            //    null);


            //var autoMocker = new AutoMocker();

            //var userRepositoryMock = autoMocker.GetMock<IUserRepository>();
            //userRepositoryMock
            //    .Setup(e => e.GetUserByEmail(AddBreadDoneCommand.UserEmail))
            //    .Returns<User>(null);

            //var recipeRepositoryMock = autoMocker.GetMock<IRecipeRepository>();

            //var commandHandler = new AddBreadDoneCommandHandler(userRepositoryMock.Object, recipeRepositoryMock.Object);


            //// Assert

            //var commandReturn = await commandHandler.Handle(AddBreadDoneCommand, new CancellationToken());


            //// Act

            //commandReturn.IsError.Should().BeTrue();
            //commandReturn.Errors.Count.Should().BeGreaterThan(0, "have errors");
            //commandReturn.Errors.Should().Contain(UserDomainErrors.UserNotFound, $"should return the {nameof(UserDomainErrors.UserNotFound)} domain error");

        }




    }
}