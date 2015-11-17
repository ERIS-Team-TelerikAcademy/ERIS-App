namespace ErisSystem.Api.Models.ResponseModels
{
    public class UserRatingResponseModel
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string HitmanId { get; set; }

        public string ClientId { get; set; }
    }
}