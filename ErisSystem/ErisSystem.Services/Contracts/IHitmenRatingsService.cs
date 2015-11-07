namespace ErisSystem.Services.Contracts
{
    using System.Linq;

    using ErisSystem.Models;

    public interface IHitmenRatingsService
    {
        IQueryable<HitmanRating> GetAll();

        IQueryable<HitmanRating> GetAllForHitman(int id);

                                // Or take ids? damn i rly dont know how this will work with the webpage
        int Add(double rating, Hitman hitman, Client client);
    }
}
