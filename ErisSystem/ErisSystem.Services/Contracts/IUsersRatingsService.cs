namespace ErisSystem.Services.Contracts
{
    using System.Linq;

    using ErisSystem.Models;

    public interface IUsersRatingsService
    {
        IQueryable<UserRating> GetAll();

        IQueryable<UserRating> GetAllForHitman(int id);

                                // Or take ids? damn i rly dont know how this will work with the webpage
        int Add(double rating, User hitman, Client client);
    }
}
