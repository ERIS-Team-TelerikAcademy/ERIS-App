namespace ErisSystem.Api.Controllers
{
    using System.Web.Http;
    using Data.Repositories;
    using Data;
    using ErisSystem.Models;
    using Services;
    using Services.Contracts;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Models.ResponseModels;

    [RoutePrefix("api/Hitmen")]
    public class UserController : ApiController
    {
        private readonly IUsersService hitmen;

        public UserController()
            : this(new UsersService(new EfGenericRepository<User>(new ErisSystemContext())))
        {
        }

        public UserController(IUsersService hitmenServices)
        {
            this.hitmen = hitmenServices;
        }
        
        [Route("{userName}")]
        [HttpGet]
        public IHttpActionResult GetHitmanByUserName(string userName)
        {
            var result = Mapper.Map<UserResponseModel>(this.hitmen
                .GetByUserName(userName));

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Gets all hitmen in the db
        /// </summary>
        /// <returns>IQueryable of all the hitmen</returns>
        [Route("all")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = this.hitmen
                .GetAll()
                .ProjectTo<UserResponseModel>();

            return this.Ok(result);
        }
               
        /// <summary>
        /// Not sure what to do here.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("profile")]
        [HttpPut]
        public IHttpActionResult Put([FromBody]UserResponseModel model)
        {
            return this.InternalServerError(new System.NotImplementedException());
        }
    }
}