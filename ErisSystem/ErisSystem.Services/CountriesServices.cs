namespace ErisSystem.Services
{
    using System.Linq;

    using Models;
    using Contracts;
    using Data;

    public class CountriesServices : ICountriesService
    {
        private readonly IRepository<Country> countries;

        public CountriesServices(IRepository<Country> countries)
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
