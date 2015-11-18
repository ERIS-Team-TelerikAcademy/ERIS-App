namespace ErisSystem.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Api.Models.ResponseModels;
    using Models;
    using Api.Controllers;

    using MyTested.WebApi;
    using DummyObjects;
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
    }
}
