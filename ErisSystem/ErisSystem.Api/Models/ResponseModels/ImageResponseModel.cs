namespace ErisSystem.Api.Models.ResponseModels
{
    public class ImageResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        public int UserId { get; set; }
    }
}