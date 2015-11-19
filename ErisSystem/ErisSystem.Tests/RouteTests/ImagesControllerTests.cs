namespace ErisSystem.Tests.RouteTests
{
    using System.Net.Http;

    using Api.Controllers;
    using Api.Models.RequestModels;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Newtonsoft.Json;

    [TestClass]
    public class ImagesControllerTests
    {
        [TestMethod]
        public void ImagesGetShouldMapToCorrectMethod()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Images")
                .WithHttpMethod(HttpMethod.Get)
                .To<ImagesController>(c => c.Get());
        }

        [TestMethod]
        public void ImagesGetForCertainUserShouldMapToCorrectMethod()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Images/d1f526fa-321d-4c4f-91fd-7c188bcf3cbc")
                .To<ImagesController>(c => c.Get("d1f526fa-321d-4c4f-91fd-7c188bcf3cbc"));
        }

        [TestMethod]
        public void ImagesUploadingShouldMapToCorrectMethod()
        {
            var imageRequestModel = new ImageRequestModel()
            {
                Name = "rabbit",
                Extension = "png",
                UserId = "d1f526fa-321d-4c4f-91fd-7c188bcf3cbc",
                Data = "{imageAsBase64}"
            };

            MyWebApi
                .Routes()
                .ShouldMap("api/Images/")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(JsonConvert.SerializeObject(imageRequestModel))
                .To<ImagesController>(c => c.Post(imageRequestModel));
        }

        [TestMethod]
        public void ImageDeletionShouldMapToCorrectMethod()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Images/3")
                .WithHttpMethod(HttpMethod.Delete)
                .To<ImagesController>(c => c.Delete(3));
        }
    }
}