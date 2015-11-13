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
    using ErisSystem.Models.Enumerators;

    [RoutePrefix("api/Contracts")]
    public class ContractsController : ApiController
    {
        private readonly IContractsService contracts;

        public ContractsController(IContractsService contractsServices)
        {
            this.contracts = contractsServices;
        }

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

        [Route("new-contract")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ContractResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // var contract = new Contract
            // {
            //     ClientId = model.ClientId,
            //     HitmanId = model.HitmanId,
            //     HitStatus = (HitStatus)model.HitStatus,
            //     Status = (ConnectionStatus)model.Status,
            //     Deadline = model.Deadline
            // };

            var newContractId = this.contracts.Add(
                model.HitmanId, 
                model.ClientId, 
                model.Deadline);

            // TODO: Figure this out - either change the Add service or add dependencies.
            return this.Created(this.Url.ToString(), newContractId);
        }

        [Route("update-contract")]
        [HttpPut]
        public IHttpActionResult Put(ContractResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var updated = this.contracts.Update(model.Id, (ConnectionStatus)model.Status, (HitStatus)model.HitStatus);

            if (updated == null)
            {
                return this.NotFound();
            }

            return this.Ok(updated);
        }
    }
}