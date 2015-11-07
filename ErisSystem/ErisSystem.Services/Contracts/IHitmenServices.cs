namespace ErisSystem.Services.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using ErisSystem.Models;
    using Models.Enumerators;

    public interface IHitmenServices
    {
        IQueryable<Hitman> GetAll();

        Hitman GetById(int id);
                                                 //Gender as string ? hmmm parse it to Genders in Rest api maybe
        int Add(string nickName, string aboutMe, Genders gender, ICollection<Image> images = null, ICollection<Country> countriesOfOperation = null);

        void Delete(Hitman hitman);

    }
}
