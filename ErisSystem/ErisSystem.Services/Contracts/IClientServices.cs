namespace ErisSystem.Services.Contracts
{
    using ErisSystem.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public interface IClientServices
    {
        IQueryable<Client> GetAll();

        Client GetById(int id);

        int Add(string nickName, string password);

        void Delete(Client client);
    }
}
