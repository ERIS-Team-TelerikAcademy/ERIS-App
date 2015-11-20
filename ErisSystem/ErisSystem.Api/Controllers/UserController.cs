namespace ErisSystem.Api.Controllers
{
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Repositories;
    using ErisSystem.Models;
    using Models.ResponseModels;
    using Services;
    using Services.Contracts;

    [RoutePrefix("api/Hitmen")]
    public class UserController : ApiController
    {
        private readonly IUsersService users;

        public UserController()
            : this(new UsersService(new EfGenericRepository<User>(new ErisSystemContext())))
        {
        }

        public UserController(IUsersService hitmenServices)
        {
            this.users = hitmenServices;
        }

        [Route("{userName}")]
        [HttpGet]
        public IHttpActionResult GetHitmanByUserName(string userName)
        {
            var result = Mapper.Map<UserResponseModel>(this.users
                .GetByUserName(userName));

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Route("byId/{id}")]
        [HttpGet]
        public IHttpActionResult GetHitmanById(string id)
        {
            var result = Mapper.Map<UserResponseModel>(this.users
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
            var result = this.users
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
        [Authorize]
        [HttpPut]
        public IHttpActionResult Put(UserResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = this.users.Update(
              model.UserName,
              model.AboutMe,
              model.Gender,
              model.IsWorking,
              model.DateOfBirth);

            return this.Ok(result);
        }
    }
}