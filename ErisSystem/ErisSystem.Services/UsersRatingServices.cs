namespace ErisSystem.Services
{
    using System;
    using System.Linq;
    using Models;
    using ErisSystem.Services.Contracts;
    using Data;

    public class UsersRatingServices : IUsersRatingsService
    {
        private readonly IRepository<UserRating> userRating;

        public UsersRatingServices(IRepository<UserRating> hitmenRating)
        {
            this.userRating = hitmenRating;
        }

        public int Add(int ratingScore, User hitman, User client)
        {
            var rating = new UserRating();
            rating.Rating = ratingScore;
            rating.Hitman = hitman;
            rating.Client = client;

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
