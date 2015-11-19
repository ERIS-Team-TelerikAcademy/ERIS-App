namespace ErisSystem.Tests.Setup.DummyObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Models;

    using Moq;

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
    }
}
