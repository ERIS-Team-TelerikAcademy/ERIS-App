namespace ErisSystem.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Contracts;
    using Data;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> user;

        public UsersService(IRepository<User> user)
        {
            this.user = user;
        }

        public int Add(string nickName, string aboutMe, bool gender, string password, bool isWorking = false, ICollection < Image> images = null, ICollection<Country> countriesOfOperation = null)
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
                IsWorking = isWorking,
                Images = images,
                Password = password,
                CountriesOfOperation = countriesOfOperation,
                RegistrationDate = DateTime.Now
            };

            this.user.Add(hitman);
            return this.user.SaveChanges();
        }

        public void Delete(User hitman)
        {
            this.user.Delete(hitman);
            this.user.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            var result = this.user.All();

            return result;
        }

        public User GetById(int id)
        {
            var result = this.user.GetById(id);

            return result;
        }
    }
}
