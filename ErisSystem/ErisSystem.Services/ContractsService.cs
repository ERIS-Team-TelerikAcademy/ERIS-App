namespace ErisSystem.Services
{
    using System;
    using System.Linq;

    using ErisSystem.Models;
    using ErisSystem.Models.Enumerators;
    using ErisSystem.Services.Contracts;
    using Data;

    class ContractsService : IContractsService
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

        public int Add(string hitmanNickname, string clientNickname, ConnectionStatus connectionStatus, HitStatus hitStatus, DateTime deadline)
        {
            var hitman = this.hitmen
                .All()
                .Where(x => x.NickName == hitmanNickname)
                .FirstOrDefault();
            var client = this.clients
                .All()
                .Where(x => x.NickName == clientNickname)
                .FirstOrDefault();
            if (hitman == null)
            {
                throw new ArgumentException("Invalid hitman nickname!");
            }
            else if (client == null)
            {
                throw new ArgumentException("Invalid client nickname!");
            }

            var contract = new Contract();
            contract.Client = client;
            contract.Hitman = hitman;
            contract.Status = connectionStatus;
            contract.HitStatus = hitStatus;
            contract.Deadline = deadline;

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
    }
}
