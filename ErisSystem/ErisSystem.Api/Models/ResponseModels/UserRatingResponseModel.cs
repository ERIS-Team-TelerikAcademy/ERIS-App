namespace ErisSystem.Api.Models.ResponseModels
{
    public class UserRatingResponseModel
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public int HitmanId { get; set; }

        public int ClientId { get; set; }
    }
}