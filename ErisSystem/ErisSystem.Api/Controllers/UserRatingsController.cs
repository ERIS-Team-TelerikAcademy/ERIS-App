namespace ErisSystem.Api.Controllers
{
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Models.ResponseModels;
    using Services.Contracts;

    [RoutePrefix("api/Ratings")]
    public class UserRatingsController : ApiController
    {
        private readonly IUsersRatingsService ratings;

        public UserRatingsController(IUsersRatingsService ratingsServices)
        {
            this.ratings = ratingsServices;
        }

        /// <summary>
        /// Gets all ratings for selected hitman
        /// </summary>
        /// <param name="id">The Id of the hitman</param>
        /// <returns>A collection of UserRatings</returns>
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetRatingsForUser(string id)
        {
            var result = this.ratings.GetAllForHitman(id).ProjectTo<UserRatingResponseModel>();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Route("rate")]
        [HttpPost]
        public IHttpActionResult AddRating([FromBody]UserRatingResponseModel model)
        {
            var ratingId = this.ratings.Add(model.Rating, model.HitmanId, model.ClientId);

            return this.Ok(ratingId);
        }
    }
}