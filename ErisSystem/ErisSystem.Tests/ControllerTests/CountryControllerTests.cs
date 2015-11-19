namespace ErisSystem.Tests.ControllerTests
{
    using Api.Controllers;
    using Api.Models.ResponseModels;
    using Setup.DummyObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using System.Linq;

    [TestClass]
    public class CountryControllerTests
    {        
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
