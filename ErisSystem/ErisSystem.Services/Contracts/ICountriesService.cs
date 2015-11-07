namespace ErisSystem.Services.Contracts
{
    using System.Linq;

    using ErisSystem.Models;

    public interface ICountriesService
    {
        IQueryable<Country> GetAll();
    }
}
