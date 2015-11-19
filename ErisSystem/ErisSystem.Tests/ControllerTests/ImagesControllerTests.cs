namespace ErisSystem.Tests.ControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ErisSystem.Api.Controllers;
    using ErisSystem.Api.Models.RequestModels;
    using ErisSystem.Api.Models.ResponseModels;
    using ErisSystem.Tests.Setup.DummyObjects;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using System.Threading.Tasks;
    using System.Web.Http;

    [TestClass]
    public class ImagesControllerTests
    {
        [TestMethod]
        public void GettingAllImagesShouldReturnAList()
        {
            MyWebApi
                .Controller<ImagesController>()
                .WithResolvedDependencies(DummyServices.GetDummyImagesService())
                .Calling(c => c.Get())
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<ImageResponseModel>>()
                .Passing(c => c.Count == DummyRepositories.NumberOfTestObjects);
        }

        [TestMethod]
        public async Task GettingImagesForUserShouldReturnAList()
        {
            var result = await MyWebApi
                .Controller<ImagesController>()
                .WithResolvedDependencies(DummyServices.GetDummyImagesService())
                .Calling(c => c.Get("1"))
                .ShouldReturn()
                .ResultOfType<Task<IHttpActionResult>>()
                .AndProvideTheModel();
                //.WithResponseModelOfType<List<ImageResponseModel>>()
                //.Passing(c => c.Count == 1 && c[0].UserId == "1");
        }

        [TestMethod]
        public async Task PostingImagesShouldCreateAnImageAndReturnItsId()
        {
            Random random = new Random();

            var randomUserId = DummyRepositories.DummyHitmenRepository()
                .All()
                .Select(x => x.Id)
                .FirstOrDefault(x => x == random.Next(0, DummyRepositories.NumberOfTestObjects).ToString());

            var result = await MyWebApi
                .Controller<ImagesController>()
                .WithResolvedDependencies(DummyServices.GetDummyImagesService())
                .Calling(c => c.Post(new ImageRequestModel()
                {
                    Name = "SUPER COOL TEST IMAGE",
                    Extension = "gif",
                    Data = "R0lGODlhAQABAIAAAP///////yH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
                    UserId = randomUserId,
                }))
                .ShouldReturn()
                .ResultOfType<Task<IHttpActionResult>>()
                .AndProvideTheModel();

                //.WithResponseModelOfType<int>()
                //.Passing(c => c == DummyRepositories.NumberOfTestObjects + 1);
        }

        [TestMethod]
        public async Task DeletingImagesShouldWorkCorrectly()
        {
            var dummyImageService = DummyServices.GetDummyImagesService();
            var currentImagesCount = dummyImageService.All().Count();

            var result = await MyWebApi
                .Controller<ImagesController>()
                .WithResolvedDependencies(dummyImageService)
                .Calling(c => c.Delete(3))
                .ShouldReturn()
                .ResultOfType<Task<IHttpActionResult>>()
                .AndProvideTheModel();

            var newImageCount = dummyImageService.All().Count();

            Assert.IsTrue(newImageCount == currentImagesCount - 1);
        }
    }
}
