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

        private readonly IRepository<User> users;

        public ContractsService(
            IRepository<Contract> contracts,
            IRepository<User> hitmen)
        {
            this.contracts = contracts;
            this.users = hitmen;
        }

        public int Add(string hitmanId, string clientId, DateTime deadline, string targetName = null, string location = null)
        {
            var hitmanFromDb = this.users
                .All()
                .Where(x => x.Id == hitmanId)
                .FirstOrDefault();
            var client = this.users
                .All()
                .Where(x => x.Id == clientId)
                .FirstOrDefault();
            if (hitmanFromDb == null)
            {
                throw new ArgumentException("Invalid hitman!");
            }
            else if (client == null)
            {
                throw new ArgumentException("Invalid client!");
            }

            var contract = new Contract();
            contract.Client = client;
            contract.Hitman = hitmanFromDb;
            contract.Deadline = deadline;
            contract.TargetName = targetName;
            contract.Location = location;

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

        public int UpdateConnectionStatus(int id, HitStatus hitStatus, ConnectionStatus connectionStatus)
        {
            var contract = this.contracts.GetById(id);

            if (contract == null)
            {
                return -1;
            }


            contract.Status = connectionStatus;
            this.contracts.Update(contract);

            return this.contracts.SaveChanges();
        }

        public int UpdateConnectionStatus(int id, ConnectionStatus connectionStatus)
        {
            var contract = this.contracts.GetById(id);
            if (contract == null)
            {
                return -1;
            }

            contract.Status = connectionStatus;
            this.contracts.Update(contract);

            return this.contracts.SaveChanges();
        }

        public IQueryable<Contract> GetAllWhereClient(string userId)
        {
            var result = this.contracts
                .All()
                .Where(x => x.ClientId == userId);

            return result;
        }

        public IQueryable<Contract> GetAllWhereHitman(string userId)
        {
            var result = this.contracts
                .All()
                .Where(x => x.HitmanId == userId);

            return result;
        }
    }
}
