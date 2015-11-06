using ErisSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace ErisSystem.Services.Contracts
{
    public interface IClientServices
    {
        IQueryable<Client> GetAll();

        Client GetById(int id);

        int Add(string nickName);

        void Delete(Client client);
    }
}
