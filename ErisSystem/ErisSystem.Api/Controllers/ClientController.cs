﻿namespace ErisSystem.Api.Controllers
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

        [Route("all")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = this.clients
                .GetAll()
                .ProjectTo<ClientResponseModel>();

            return this.Ok(result);
        }

        [Route("register")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ClientResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // TODO: Improve client registration
            var newClientId = this.clients.Add(model.Nickname, model.Password, model.RegistrationDate);

            return this.Created(this.Url.ToString(), newClientId);
        }

        [HttpPut]
        public IHttpActionResult Put(ClientResponseModel model)
        {
            return this.InternalServerError(new System.NotImplementedException());
        }
    }
}