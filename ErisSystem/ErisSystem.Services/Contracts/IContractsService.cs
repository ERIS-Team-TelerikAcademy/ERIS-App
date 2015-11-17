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

        int Add(string hitmanId, string clientId, DateTime deadLine);

        int UpdateConnectionStatus(int id, HitStatus hitStatus, ConnectionStatus connectionStatus);

        int UpdateConnectionStatus(int id, ConnectionStatus connectionStatus);

        int UpdateHitStatus(int id, HitStatus hitStatus);
    }
}
