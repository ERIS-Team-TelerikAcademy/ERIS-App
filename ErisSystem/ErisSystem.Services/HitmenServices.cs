namespace ErisSystem.Services
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Models.Enumerators;
    using ErisSystem.Services.Contracts;
    using Data;

    class HitmenServices : IHitmenServices
    {
        private readonly IRepository<Hitman> hitmen;

        public HitmenServices(IRepository<Hitman> hitmen)
        {
            this.hitmen = hitmen;
        }

        public int Add(string nickName, string aboutMe, Genders gender, ICollection<Image> images = null, ICollection<Country> countriesOfOperation = null)
        {
            var isValidUserName = Validator.ValidateStringLenght(3, 20, nickName);
            var isValidAboutMe = Validator.ValidateStringLenght(0, 250, aboutMe);

            if (!isValidUserName)
            {
                throw new ArgumentOutOfRangeException("Invalid user name length");
            }
            else if (!isValidAboutMe)
            {
                throw new ArgumentOutOfRangeException("Invalid about me name length");
            }

            var hitman = new Hitman();
            hitman.NickName = nickName;
            hitman.AboutMe = aboutMe;
            hitman.Gender = gender;
            hitman.Images = images;
            hitman.CountriesOfOperation = countriesOfOperation;

            this.hitmen.Add(hitman);
            return this.hitmen.SaveChanges();
        }

        public void Delete(Hitman hitman)
        {
            this.hitmen.Delete(hitman);
            this.hitmen.SaveChanges();
        }

        public IQueryable<Hitman> GetAll()
        {
            var result = this.hitmen.All();

            return result;
        }

        public Hitman GetById(int id)
        {
            var result = this.hitmen.GetById(id);

            return result;
        }
    }
}
