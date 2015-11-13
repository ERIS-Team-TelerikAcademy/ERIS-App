namespace ErisSystem.Services.Contracts
{
    using System.Linq;

    using ErisSystem.Models;
    using Models.Enumerators;
    using System;

    public interface IContractsService
    {
        IQueryable<Contract> GetAll();

        Contract GetById(int id);

        int Add(int hitmanId, int clientId, DateTime deadLine);

        int UpdateConnectionStatus(int id, ConnectionStatus connectionStatus);

        int UpdateHitStatus(int id, HitStatus hitStatus);
    }
}
