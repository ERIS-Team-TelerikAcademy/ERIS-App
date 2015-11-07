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
    using ErisSystem.Models.Enumerators;

    [RoutePrefix("api/Hitmen")]
    public class HitmenController : ApiController
    {
        private readonly IHitmenServices hitmen;

        public HitmenController()
            : this(new HitmenServices(new EfGenericRepository<Hitman>(new ErisSystemContext())))
        {
        }

        public HitmenController(IHitmenServices hitmenServices)
        {
            this.hitmen = hitmenServices;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetHitmanById(int id)
        {
            var result = Mapper.Map<HitmanResponseModel>(this.hitmen
                .GetById(id));

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = this.hitmen
                .GetAll()
                .ProjectTo<HitmanResponseModel>();

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(HitmanResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newHitmanId = this.hitmen.Add(
                model.Nickname,
                model.AboutMe,
                (Genders)model.Gender);

            return this.Created(this.Url.ToString(), newHitmanId);
        }

        [HttpPut]
        public IHttpActionResult Put(HitmanResponseModel model)
        {
            return this.InternalServerError(new System.NotImplementedException());
        }
    }
}