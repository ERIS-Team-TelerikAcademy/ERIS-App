namespace ErisSystem.Services
{
    using System.Linq;

    using Contracts;
    using Data;
    using Models;

    public class CountriesService : ICountriesService
    {
        private readonly IRepository<Country> countries;

        public CountriesService(IRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> GetAll()
        {
            var result = this.countries.All().OrderBy(x => x.Name);

            return result;
        }
    }
}
