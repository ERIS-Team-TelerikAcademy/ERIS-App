﻿namespace ErisSystem.Services
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

        public int Add(string hitmanNickname, string clientNickname, DateTime deadline)
        {
            var hitmanFromDb = this.hitmen
                .All()
                .Where(x => x.Nickname == hitmanNickname)
                .FirstOrDefault();
            var client = this.clients
                .All()
                .Where(x => x.Nickname == clientNickname)
                .FirstOrDefault();
            if (hitmanFromDb == null)
            {
                throw new ArgumentException("Invalid hitman nickname!");
            }
            else if (client == null)
            {
                throw new ArgumentException("Invalid client nickname!");
            }

            var contract = new Contract();
            contract.Client = client;
            contract.Hitman = hitmanFromDb;
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