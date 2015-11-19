namespace ErisSystem.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Api.Models.ResponseModels;
    using Api.Controllers;
    using Setup.DummyObjects;

    using MyTested.WebApi;
    using System.Linq;

    [TestClass]
    public class UserRatingControllerTests
    {
        [TestMethod]
        public void GetRatingsByUserShouldReturnTheProperRatings()
        {
            MyWebApi
                .Controller<UserRatingsController>()
                .WithResolvedDependencies(DummyServices.GetDummyUserRatingsService())
                .Calling(c => c.GetRatingsForUser("TestId3"))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<IQueryable<UserRatingResponseModel>>()
                .Passing(r => r.Count() == DummyRepositories.NumberOfTestObjects / 2);
        }

        [TestMethod]
        public void GetRatingsByUserShouldReturnNotFoundWithInvalidId()
        {
            MyWebApi
                .Controller<UserRatingsController>()
                .WithResolvedDependencies(DummyServices.GetDummyUserRatingsService())
                .Calling(c => c.GetRatingsForUser("Not-availableId"))
                .ShouldReturn()
                .NotFound();
        }

        [TestMethod]
        public void AddRatingShouldAddARatingAndReturnItsInt()
        {
            MyWebApi
                .Controller<UserRatingsController>()
                .WithResolvedDependencies(DummyServices.GetDummyUserRatingsService())
                .Calling(c => c.AddRating(new UserRatingResponseModel
                {
                    ClientId = "Test",
                    HitmanId = "Test2",
                    Rating = 1
                }))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<int>()
                .Passing(r => r == DummyRepositories.NumberOfTestObjects - 1);
        }
    }
}
