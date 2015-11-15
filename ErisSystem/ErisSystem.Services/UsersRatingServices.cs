namespace ErisSystem.Services
{
    using System.Linq;
    using Models;
    using Contracts;
    using Data;

    public class UsersRatingServices : IUsersRatingsService
    {
        private readonly IRepository<UserRating> userRating;

        public UsersRatingServices(IRepository<UserRating> hitmenRating)
        {
            this.userRating = hitmenRating;
        }

        public int Add(int ratingScore, int hitmanId, int clientId)
        {
            var rating = new UserRating();
            rating.Rating = ratingScore;
            rating.HitmanId = hitmanId;
            rating.ClientId = clientId;

            this.userRating.Add(rating);

            return this.userRating.SaveChanges();
        }

        public IQueryable<UserRating> GetAll() 
        {
            var result = this.userRating.All();

            return result;
        }

        public IQueryable<UserRating> GetAllForHitman(int id)
        {
            var result = this.userRating
                .All()
                .Where(x => x.HitmanId == id);

            return result;
        }
    }
}
