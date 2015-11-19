namespace ErisSystem.Tests.Setup.DummyObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Models.Enumerators;
    using Models;

    using Moq;
    using Api.Models.RequestModels;

    internal static class DummyRepositories
    {
        internal const int NumberOfTestObjects = 20;

        internal static IRepository<Country> DummyCountriesRepository()
        {
            var repo = new Mock<IRepository<Country>>();

            repo.Setup(r => r.All()).Returns(() =>
            {
                var countries = new List<Country>();

                for (int i = 0; i < NumberOfTestObjects; i++)
                {
                    countries.Add(new Country
                    {
                        Id = i,
                        Name = "TestCountry" + i
                    });
                }

                return countries.AsQueryable();
            });

            return repo.Object;
        }

        internal static IRepository<User> DummyHitmenRepository()
        {
            var repo = new Mock<IRepository<User>>();

            var users = new List<User>();

            for (int i = 0; i < NumberOfTestObjects; i++)
            {
                users.Add(new User
                {
                    Id = i.ToString(),
                    RegistrationDate = DateTime.Now,
                    AboutMe = "Test About Me" + i,
                    DateOfBirth = DateTime.Now.AddYears(i),
                    Gender = true,
                    IsWorking = i % 2 == 0
                });
            }

            repo.Setup(r => r.All()).Returns(() =>
            {
                return users.AsQueryable();
            });

            return repo.Object;
        }

        internal static IRepository<Contract> DummyContractsRepository()
        {
            var repo = new Mock<IRepository<Contract>>();

            var contracts = new List<Contract>();

            for (int i = 0; i < NumberOfTestObjects; i++)
            {
                contracts.Add(new Contract
                {
                    ClientId = (i % 2 == 0 ? i : 3).ToString(),
                    HitmanId = (i % 2 == 0 ? i : 3).ToString() + "hitman",
                    Deadline = DateTime.Now,
                    Status = ConnectionStatus.Pending,
                    Id = i
                });
            }

            repo.Setup(r => r.GetById(It.Is<int>(x => x == 4))).Returns(() => 
            {
                return contracts.Where(c => c.Id == 4).FirstOrDefault();
            });

            repo.Setup(r => r.All()).Returns(() =>
            {
                return contracts.AsQueryable();
            });

            return repo.Object;
        }

        internal static IRepository<UserRating> DummyUserRatingsRepository()
        {
            var repo = new Mock<IRepository<UserRating>>();
            var ratings = new List<UserRating>();

            for (int i = 0; i < NumberOfTestObjects; i++)
            {
                ratings.Add(new UserRating
                {
                    Id = i,
                    ClientId = "TestId" + i,
                    HitmanId = "TestId" + (i % 2 == 0 ? i : 3),
                    Rating = i % 6
                });
            }

            repo.Setup(r => r.All()).Returns(() =>
            {
                return ratings.AsQueryable();
            });

            repo.Setup(r => r.SaveChanges()).Returns(ratings.Last().Id);

            repo.Setup(r => r.Add(It.IsAny<UserRating>())).Callback<UserRating>(ur =>
            {
                ur.Id = ratings.LastOrDefault().Id + 1;
                ratings.Add(ur);
            });

            return repo.Object;
        }

        internal static IRepository<Image> DummyImagesRepository()
        {
            var repository = new Mock<IRepository<Image>>();
            var images = new List<Image>();

            for (int i = 0; i < NumberOfTestObjects; i++)
            {
                var user = DummyHitmenRepository()
                    .All()
                    .FirstOrDefault(u => u.Id == i.ToString());

                images.Add(new Image()
                {
                    Id = i,
                    Name = "Image #" + i,
                    Extension = ".png",
                    UserId = user.Id,
                    User = user
                });
            }

            repository.Setup(r => r.All()).Returns(() =>
            {
                return images.AsQueryable();
            });

            repository
                .Setup(r => r.Add(It.IsAny<Image>()))
                .Callback<Image>(i =>
                {
                    i.Id = images.LastOrDefault().Id + 1;
                    images.Add(i);
                });

            repository.Setup(r => r.SaveChanges()).Returns(images.Last().Id);

            repository
                .Setup(r => r.Delete(It.IsAny<Image>()))
                .Callback<Image>(i =>
                {
                    images.RemoveAt(i.Id);
                });

            return repository.Object;
        }
    }
}
