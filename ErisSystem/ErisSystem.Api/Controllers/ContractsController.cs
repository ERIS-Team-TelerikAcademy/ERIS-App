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

    [RoutePrefix("api/Contracts")]
    public class ContractsController : ApiController
    {
        private readonly IContractsService contracts;

        public ContractsController(IContractsService contractsServices)
        {
            this.contracts = contractsServices;
        }

        // TODO: Ninject or some other form of dependency inversion, this is getting ridiculous.
        public ContractsController()
            :this(new ContractsService(
                new EfGenericRepository<Contract>(new ErisSystemContext()), 
                new EfGenericRepository<Client>(new ErisSystemContext()),
                new EfGenericRepository<Hitman>(new ErisSystemContext())))
        {
        }


        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetClientById(int id)
        {
            var result = Mapper.Map<ContractResponseModel>(this.contracts
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
            var result = this.contracts
                .GetAll()
                .ProjectTo<ContractResponseModel>();

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(ContractResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // TODO: Figure this out - either change the Add service or add dependencies.
            return this.InternalServerError(new System.NotImplementedException());
        }

        [HttpPut]
        public IHttpActionResult Put(ContractResponseModel model)
        {
            return this.InternalServerError(new System.NotImplementedException());
        }
    }
}