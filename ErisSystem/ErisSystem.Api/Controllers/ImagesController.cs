namespace ErisSystem.Api.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Threading.Tasks;

    using Services;
    using Services.Contracts;
    using Data.Repositories;
    using Data;
    using ErisSystem.Models;
    using Models.ResponseModels;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Dropbox.Api;

    [RoutePrefix("api/Images")]
    [Authorize]
    public class ImagesController : ApiController
    {
        private readonly IImagesService images;

        public ImagesController(IImagesService imagesService)
        {
            this.images = imagesService;
        }

        /// <summary>
        /// Retrieves all images for all users. Useful for listing.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var result = this.images
                .GetAll()
                .ProjectTo<ImageResponseModel>();
                
            return this.Ok(result);
        }

        /// <summary>
        /// Returns the image for a certain user.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns></returns>
        public IHttpActionResult Get(int userId)
        {
            var result = this.images
                .GetAll()
                .Where(x => x.UserId == userId)
                .SingleOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok();
        }

        /// <summary>
        /// Uploads an image for a certain user.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Post(int forUserId, [FromBody]ImageResponseModel sentImage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            int createdImageId = await this.images.Add(sentImage.Data, sentImage.Extension, forUserId);

            return this.Ok(createdImageId);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
