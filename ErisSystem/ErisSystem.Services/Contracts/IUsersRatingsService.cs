namespace ErisSystem.Services.Contracts
{
    using System.Linq;

    using ErisSystem.Models;

    public interface IUsersRatingsService
    {
        IQueryable<UserRating> GetAll();

        IQueryable<UserRating> GetAllForHitman(string id);

                                
        int Add(int rating, string hitmanId, string clientId);
    }
}
