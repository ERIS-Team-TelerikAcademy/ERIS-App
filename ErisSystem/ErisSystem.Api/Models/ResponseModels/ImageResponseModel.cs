namespace ErisSystem.Api.Models.ResponseModels
{
    public class ImageResponseModel
    {
        public byte[] Data { get; set; }

        public string Extension { get; set; }

        public int UserId { get; set; }
    }
}