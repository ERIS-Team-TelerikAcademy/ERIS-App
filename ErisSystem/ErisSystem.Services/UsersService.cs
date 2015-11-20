namespace ErisSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Data;
    using Models;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> user)
        {
            this.users = user;
        }

        public int Add(string nickName, string aboutMe, bool gender, string password, bool isWorking = false, ICollection<Image> images = null, ICollection<Country> countriesOfOperation = null)
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
                UserName = nickName,
                AboutMe = aboutMe,
                Gender = gender,
                IsWorking = isWorking,
                Images = images,
                CountriesOfOperation = countriesOfOperation,
                RegistrationDate = DateTime.Now
            };

            this.users.Add(hitman);
            return this.users.SaveChanges();
        }

        public void Delete(User hitman)
        {
            this.users.Delete(hitman);
            this.users.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            var result = this.users.All();

            return result;
        }

        public User GetById(string id)
        {
            var result = this.users.GetById(id);

            return result;
        }

        public User GetByUserName(string userName)
        {
            var result = this.users
                .All()
                .Where(x => x.UserName == userName)
                .FirstOrDefault();

            return result;
        }

        public int Update(string userName, string aboutMe, bool gender, bool isWorking, DateTime dateOfBirth)
        {
            var user = this.GetByUserName(userName);

            if (user == null)
            {
                throw new ArgumentNullException("No such user exists");
            }

            user.AboutMe = aboutMe;
            user.Gender = gender;
            user.IsWorking = isWorking;
            user.DateOfBirth = dateOfBirth;
            this.users.Update(user);

            return this.users.SaveChanges();
        }
    }
}
