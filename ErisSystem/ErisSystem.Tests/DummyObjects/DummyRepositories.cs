namespace ErisSystem.Tests.DummyObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Models;

    using Moq;

    internal static class DummyRepositories
    {
        internal const int NumberOfTestCountries = 20;

        internal static IRepository<Country> DummyCountriesRepository()
        {
            var repo = new Mock<IRepository<Country>>();

            repo.Setup(r => r.All()).Returns(() =>
            {
                var countries = new List<Country>();

                for (int i = 0; i < NumberOfTestCountries; i++)
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
    }
}
