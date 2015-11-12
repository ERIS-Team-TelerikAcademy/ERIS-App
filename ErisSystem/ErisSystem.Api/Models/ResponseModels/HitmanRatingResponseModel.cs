namespace ErisSystem.Api.Models.ResponseModels
{
    public class HitmanRatingResponseModel
    {
        public int Id { get; set; }

        public double Rating { get; set; }

        public int HitmanId { get; set; }

        public int ClientId { get; set; }
    }
}