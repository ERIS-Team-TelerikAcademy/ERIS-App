namespace ErisSystem.Services.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using ErisSystem.Models;
    using Models.Enumerators;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(int id);
                                               
        int Add(string nickName, string aboutMe, bool gender, string password, bool isWorking = false, ICollection<Image> images = null, ICollection<Country> countriesOfOperation = null);

        void Delete(User hitman);

        User GetByUserName(string userName);

    }
}
