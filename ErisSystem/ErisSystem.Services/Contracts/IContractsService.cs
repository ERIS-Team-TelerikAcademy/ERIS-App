namespace ErisSystem.Services.Contracts
{
    using System;
    using System.Linq;

    using ErisSystem.Models;
    using Models.Enumerators;

    public interface IContractsService
    {
        IQueryable<Contract> GetAll();

        IQueryable<Contract> GetAllWhereClient(string userId);

        IQueryable<Contract> GetAllWhereHitman(string userId);

        Contract GetById(int id);

        int Add(string hitmanId, string clientId, DateTime deadLine, string targetName, string location);

        int UpdateConnectionStatus(int id, ConnectionStatus connectionStatus);
    }
}
