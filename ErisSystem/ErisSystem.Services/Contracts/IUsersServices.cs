namespace ErisSystem.Services.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using ErisSystem.Models;
    using Models.Enumerators;

    public interface IUsersServices
    {
        IQueryable<User> GetAll();

        User GetById(int id);
                                                 //Gender as string ? hmmm parse it to Genders in Rest api maybe
        int Add(string nickName, string aboutMe, bool gender, string password, ICollection<Image> images = null, ICollection<Country> countriesOfOperation = null);

        void Delete(User hitman);

    }
}
