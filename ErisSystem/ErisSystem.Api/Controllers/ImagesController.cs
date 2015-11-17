namespace ErisSystem.Api.Controllers
{
    using System;
    using System.Web.Http;
    using System.Threading.Tasks;

    using Services.Contracts;
    using Models.ResponseModels;

    using AutoMapper.QueryableExtensions;

    [RoutePrefix("api/Images")]
    public class ImagesController : ApiController
    {
        private readonly IImagesService images;

        public ImagesController(IImagesService imagesService)
        {
            this.images = imagesService;
        }

        /// <summary>
        /// Retrieves all images for all users. Useful for listing. GET http://url:port/api/Images
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            // TODO: Fix to get all from dropbox too.
            var result = this.images
                .GetAll()
                .ProjectTo<ImageResponseModel>();
                
            return this.Ok(result);
        }

        /// <summary>
        /// Returns the image for a certain user. GET http://url:port/api/Images/{:id}
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns></returns>
        [Route("{userId}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string userId)
        {
            byte[] imageData = await this.images.GetUserImage(userId);

            if (imageData.Length == 0)
            {
                return this.BadRequest();
            }

            string imageAsBase64 = Convert.ToBase64String(imageData);
            return this.Ok(imageAsBase64);
        }

        /// <summary>
        /// Uploads an image. POST http://url:port/api/Images
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Post([FromBody]ImageResponseModel sentImage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            byte[] imageByteArray = Convert.FromBase64String(sentImage.Data);
            int createdImageId = await this.images.Add(imageByteArray, sentImage.Extension, sentImage.UserId);

            return this.Ok(createdImageId);
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}