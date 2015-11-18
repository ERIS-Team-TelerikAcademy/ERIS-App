namespace ErisSystem.Tests.ControllerTests
{
    using System.Collections.Generic;
    using Api.Controllers;
    using Api.Models.ResponseModels;
    using DummyObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class CountryControllerTests
    {
        [TestMethod]
        public void GetMethodShouldReturnAListOfCountries()
        {
            //MyWebApi
            //    .Controller<CountriesController>()
            //    .WithResolvedDependencies(DummyServices.GetDummyCountriesService())
            //    .Calling(c => c.Get())
            //    .ShouldReturn()
            //    .Ok()
            //    .WithResponseModelOfType<List<CountryResponseModel>>()
            //    .Passing(r => r.Count == DummyRepositories.NumberOfTestCountries);

        }
    }
}
