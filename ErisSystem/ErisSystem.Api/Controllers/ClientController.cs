namespace ErisSystem.Api.Controllers
{
    using System.Web.Http;
    using Data.Repositories;
    using Data;
    using ErisSystem.Models;
    using Services.Contracts;
    using Services;
    using AutoMapper;
    using Models.ResponseModels;
    using AutoMapper.QueryableExtensions;

    [RoutePrefix("api/Clients")]
    public class ClientController : ApiController
    {
        private readonly IClientServices clients;

        public ClientController(IClientServices clientServices)
        {
            this.clients = clientServices;
        }

        public ClientController()
            :this(new ClientsServices(new EfGenericRepository<Client>(new ErisSystemContext())))
        {

        }

        /// <summary>
        /// Returns the client with the queried id
        /// </summary>
        /// <param name="id">the id to search in the db for</param>
        /// <returns>A client response model with the found client</returns>
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetClientById(int id)
        {
            var result = Mapper.Map<ClientResponseModel>(this.clients
                .GetById(id));

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Gets all the clients in the db
        /// </summary>
        /// <returns>Returns an IQueryable with all the clients</returns>
        [Route("all")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = this.clients
                .GetAll()
                .ProjectTo<ClientResponseModel>();

            return this.Ok(result);
        }

        /// <summary>
        /// Adds a new client to the DB
        /// </summary>
        /// <param name="model">A clientResponseModel</param>
        /// <returns>IHttpActionResult with the ID of the added client</returns>
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ClientResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // TODO: Improve client registration
            var newClientId = this.clients.Add(model.Nickname, model.Password);

            return this.Created(this.Url.ToString(), newClientId);
        }

        /// <summary>
        /// Not sure what to do here.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("profile")]
        [HttpPut]
        public IHttpActionResult Put(ClientResponseModel model)
        {
            return this.InternalServerError(new System.NotImplementedException());
        }
    }
}