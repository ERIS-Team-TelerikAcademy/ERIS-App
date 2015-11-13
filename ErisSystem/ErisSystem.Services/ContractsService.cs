namespace ErisSystem.Services
{
    using System;
    using System.Linq;

    using ErisSystem.Models;
    using ErisSystem.Models.Enumerators;
    using ErisSystem.Services.Contracts;
    using Data;

    public class ContractsService : IContractsService
    {
        private readonly IRepository<Contract> contracts;

        private readonly IRepository<Client> clients;

        private readonly IRepository<Hitman> hitmen;

        public ContractsService(
            IRepository<Contract> contracts,
            IRepository<Client> clients,
            IRepository<Hitman> hitmen)
        {
            this.contracts = contracts;
            this.clients = clients;
            this.hitmen = hitmen;
        }

        public int Add(int hitmanId, int clientId, DateTime deadline)
        {
            var hitmanFromDb = this.hitmen
                .All()
                .Where(x => x.Id == hitmanId)
                .FirstOrDefault();
            var client = this.clients
                .All()
                .Where(x => x.Id == clientId)
                .FirstOrDefault();
            if (hitmanFromDb == null)
            {
                throw new ArgumentException("Invalid hitman nickname!");
            }
            else if (client == null)
            {
                throw new ArgumentException("Invalid client nickname!");
            }

            var contract = new Contract
            {
                Client = client,
                Hitman = hitmanFromDb,
                Deadline = deadline
            };

            this.contracts.Add(contract);
            return this.contracts.SaveChanges();
        }

        public IQueryable<Contract> GetAll()
        {
            var result = this.contracts.All();

            return result;
        }

        public Contract GetById(int id)
        {
            var result = this.contracts.GetById(id);

            return result;
        }

        public Contract Update(int id, ConnectionStatus status, HitStatus hitStatus)
        {
            var toUpdate = this.GetById(id);

            toUpdate.HitStatus = hitStatus;
            toUpdate.Status = status;

            this.contracts.Update(toUpdate);

            return toUpdate;
        }
    }
}
