namespace ErisSystem.Tests.ControllerTests
{
    using Api.Controllers;
    using Setup.DummyObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Api.Models.ResponseModels;
    using System.Linq;

    [TestClass]
    public class ContractsControllerTests
    {
        [TestMethod]
        public void GetByIdShouldReturnTheProperContracts()
        {
            MyWebApi
                .Controller<ContractsController>()
                .WithResolvedDependencies(DummyServices.GetDummyContractsService())
                .Calling(c => c.GetContractById(4))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<ContractResponseModel>()
                .Passing(c => c.Id == 4);
        }

        [TestMethod]
        public void GetShouldReturnAllContracts()
        {
            MyWebApi
               .Controller<ContractsController>()
               .WithResolvedDependencies(DummyServices.GetDummyContractsService())
               .Calling(c => c.Get())
               .ShouldReturn()
               .Ok()
               .WithResponseModelOfType<IQueryable<ContractResponseModel>>()
               .Passing(c => c.Count() == DummyRepositories.NumberOfTestObjects);
        }
    }
}
