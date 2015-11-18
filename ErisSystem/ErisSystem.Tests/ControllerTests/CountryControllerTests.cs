namespace ErisSystem.Tests.ControllerTests
{
    using System.Collections.Generic;
    using Api.Controllers;
    using Api.Models.ResponseModels;
    using DummyObjects;
    using Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using System.Linq;

    [TestClass]
    public class CountryControllerTests
    {
        private static ResponseModelFactory modelFactory;

        [AssemblyInitialize]
        public static void Init(TestContext cont)
        {
            modelFactory = new ResponseModelFactory();

            modelFactory.MapBothWays<UserRating, UserRatingResponseModel>();
            modelFactory.MapBothWays<Country, CountryResponseModel>();
        }

        [TestMethod]
        public void GetMethodShouldReturnAListOfCountries()
        {
            MyWebApi
                .Controller<CountriesController>()
                .WithResolvedDependencies(DummyServices.GetDummyCountriesService())
                .Calling(c => c.Get())
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<IQueryable<CountryResponseModel>>()
                .Passing(r => r.Count() == DummyRepositories.NumberOfTestObjects);
        }
    }
}
