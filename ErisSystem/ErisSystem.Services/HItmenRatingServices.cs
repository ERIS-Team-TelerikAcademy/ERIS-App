namespace ErisSystem.Services
{
    using System;
    using System.Linq;
    using Models;
    using ErisSystem.Services.Contracts;
    using Data;

    public class HitmenRatingServices : IHitmenRatingsService
    {
        private readonly IRepository<HitmanRating> hitmenRating;

        public HitmenRatingServices(IRepository<HitmanRating> hitmenRating)
        {
            this.hitmenRating = hitmenRating;
        }

        public int Add(double ratingScore, Hitman hitman, Client client)
        {
            var rating = new HitmanRating();
            rating.Rating = ratingScore;
            rating.Hitman = hitman;
            rating.Client = client;

            this.hitmenRating.Add(rating);

            return this.hitmenRating.SaveChanges();
        }

        public IQueryable<HitmanRating> GetAll() // Will we need it idk for now it stays
        {
            var result = this.hitmenRating.All();

            return result;
        }

        public IQueryable<HitmanRating> GetAllForHitman(int id)
        {
            var result = this.hitmenRating
                .All()
                .Where(x => x.HitmanId == id);

            return result;
        }
    }
}
