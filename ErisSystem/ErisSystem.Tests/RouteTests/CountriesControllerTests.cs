﻿namespace ErisSystem.Tests.RouteTests
{
    using Api.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class CountriesControllerTests
    {
        [TestMethod]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Countries")
                .To<CountriesController>(c => c.Get());
        }
    }
}