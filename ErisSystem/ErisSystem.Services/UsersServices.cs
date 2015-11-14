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

    public class UsersServices : IUsersServices
    {
        private readonly IRepository<User> hitmen;

        public UsersServices(IRepository<User> hitmen)
        {
            this.hitmen = hitmen;
        }

        public int Add(string nickName, string aboutMe, bool gender, string password, ICollection<Image> images = null, ICollection<Country> countriesOfOperation = null)
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

            var hitman = new User
            {
                Nickname = nickName,
                AboutMe = aboutMe,
                Gender = gender,
                Images = images,
                Password = password,
                CountriesOfOperation = countriesOfOperation,
                RegistrationDate = DateTime.Now
            };

            this.hitmen.Add(hitman);
            return this.hitmen.SaveChanges();
        }

        public void Delete(User hitman)
        {
            this.hitmen.Delete(hitman);
            this.hitmen.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            var result = this.hitmen.All();

            return result;
        }

        public User GetById(int id)
        {
            var result = this.hitmen.GetById(id);

            return result;
        }
    }
}
