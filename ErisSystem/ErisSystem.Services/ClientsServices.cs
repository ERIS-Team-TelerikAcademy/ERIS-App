namespace ErisSystem.Services
{
    using System;
    using System.Linq;

    using Models;
    using ErisSystem.Services.Contracts;
    using Data;

    public class ClientsServices : IClientServices
    {
        IRepository<Client> clients;

        public ClientsServices(IRepository<Client> clients)
        {
            this.clients = clients;
        }

        public int Add(string nickName)
        {
            var isValidUserName = Validator.ValidateStringLenght(3, 20, nickName);

            if (!isValidUserName)
            {
                throw new ArgumentOutOfRangeException("Invalid user name length");
            }

            var client = new Client();
            client.NickName = nickName;

            this.clients.Add(client);

            return this.clients.SaveChanges();
        }

        public void Delete(Client client)
        {
            this.clients.Delete(client);
            this.clients.SaveChanges();
        }

        public IQueryable<Client> GetAll()
        {
            var result = this.clients.All();

            return result;
        }

        public Client GetById(int id)
        {
            var result = this.clients.GetById(id);

            return result;
        }
    }
}
