namespace ErisSystem.Tests.DummyObjects
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

            repo.Setup(r => r.All()).Returns(() =>
            {
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

                return ratings.AsQueryable();
            });

            return repo.Object;
        }
    }
}
