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
        private readonly IUsersServices hitmen;

        public UserController()
            : this(new UsersServices(new EfGenericRepository<User>(new ErisSystemContext())))
        {
        }

        public UserController(IUsersServices hitmenServices)
        {
            this.hitmen = hitmenServices;
        }

        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id">the id to search for in the db</param>
        /// <returns>the response model of the queried user</returns>
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetHitmanById(int id)
        {
            var result = Mapper.Map<UserResponseModel>(this.hitmen
                .GetById(id));
            
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
        /// Adds a new hitman to the DB
        /// </summary>
        /// <param name="model">A hitman response model from the body of the query</param>
        /// <returns>the ID of the added hitman</returns>
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]UserResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newHitmanId = this.hitmen.Add(
                model.Nickname,
                model.AboutMe,
                model.Gender,
                model.Password);

            return this.Created(this.Url.ToString(), newHitmanId);
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