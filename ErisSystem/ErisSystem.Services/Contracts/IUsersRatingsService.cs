namespace ErisSystem.Services.Contracts
{
    using System.Linq;

    using ErisSystem.Models;

    public interface IUsersRatingsService
    {
        IQueryable<UserRating> GetAll();

        IQueryable<UserRating> GetAllForHitman(int id);

                                
        int Add(double rating, User hitman, User client);
    }
}
