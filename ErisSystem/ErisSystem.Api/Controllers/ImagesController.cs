namespace ErisSystem.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Models.RequestModels;
    using Models.ResponseModels;
    using Services.Contracts;

    using AutoMapper.QueryableExtensions;

    [RoutePrefix("api/Images")]
    public class ImagesController : ApiController
    {
        private readonly IImagesService images;

        public ImagesController(IImagesService imagesService)
        {
            this.images = imagesService;
        }

        public IHttpActionResult Get()
        {
            var result = this.images
                .All()
                .ProjectTo<ImageResponseModel>()
                .ToList();
                
            return this.Ok(result);
        }

        /// <summary>
        /// Returns the images for a certain user. GET http://url:port/api/Images/{:id}
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns></returns>
        [Route("{userId}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string userId)
        {
            var images = await this.images.GetUserImages(userId);

            if (images.Count == 0)
            {
                return this.BadRequest();
            }

            var imagesAsBase64 = new List<string>();
            foreach (var image in images)
            {
                imagesAsBase64.Add(Convert.ToBase64String(image));
            }

            return this.Ok(imagesAsBase64);
        }

        public async Task<IHttpActionResult> Post([FromBody]ImageRequestModel sentImage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            byte[] data = Convert.FromBase64String(sentImage.Data);
            int createdImageId = await this.images.Add(sentImage.Name, sentImage.Extension, sentImage.UserId, data);

            return this.Ok(createdImageId);
        }

        public IHttpActionResult Put(int id)
        {
            // Full REST is nice, but "update" an image?
            return this.BadRequest();
        }

        [Route("{imageId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int imageId)
        {
            await this.images.Delete(imageId);

            return this.Ok();
        }
    }
}