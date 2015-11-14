namespace ErisSystem.Services
{
    using System;
    using System.Linq;
    using Models;
    using ErisSystem.Services.Contracts;
    using Data;

    public class UsersRatingServices : IUsersRatingsService
    {
        private readonly IRepository<UserRating> hitmenRating;

        public UsersRatingServices(IRepository<UserRating> hitmenRating)
        {
            this.hitmenRating = hitmenRating;
        }

        public int Add(double ratingScore, User hitman, Client client)
        {
            var rating = new UserRating();
            rating.Rating = ratingScore;
            rating.Hitman = hitman;
            rating.Client = client;

            this.hitmenRating.Add(rating);

            return this.hitmenRating.SaveChanges();
        }

        public IQueryable<UserRating> GetAll() // Will we need it idk for now it stays
        {
            var result = this.hitmenRating.All();

            return result;
        }

        public IQueryable<UserRating> GetAllForHitman(int id)
        {
            var result = this.hitmenRating
                .All()
                .Where(x => x.HitmanId == id);

            return result;
        }
    }
}
