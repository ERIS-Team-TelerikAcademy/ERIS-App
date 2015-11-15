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

        /// <summary>
        /// Gets the contract with id == id
        /// </summary>
        /// <param name="id">The id for searching the DB</param>
        /// <returns>A client response model for the client side.</returns>
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetContractById(int id)
        {
            var result = Mapper.Map<ContractResponseModel>(this.contracts
                .GetById(id));

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        /// <summary>
        /// An endpoint for aquiring all contracts in the DB
        /// </summary>
        /// <returns>IQueryable of all the contracts</returns>
        [Route("all")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = this.contracts
                .GetAll()
                .ProjectTo<ContractResponseModel>();

            return this.Ok(result);
        }

        /// <summary>
        /// Endpoint for registering a new contract
        /// </summary>
        /// <param name="model">Gets a response model from the client side</param>
        /// <returns>an HttpActionResult with the id of the created contract</returns>
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

        /// <summary>
        /// An endpoint for updating the info on a contract
        /// </summary>
        /// <param name="model">Gets a contract model with the new info</param>
        /// <returns>ID of the updated contract</returns>
        [Route("update-contract")]
        [HttpPut]
        public IHttpActionResult Put(ContractResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var updated = this.contracts.UpdateConnectionStatus(model.Id, (HitStatus)model.Status, (ConnectionStatus)model.HitStatus);

            if (updated == -1)
            {
                return this.NotFound();
            }

            return this.Ok(updated);
        }
    }
}