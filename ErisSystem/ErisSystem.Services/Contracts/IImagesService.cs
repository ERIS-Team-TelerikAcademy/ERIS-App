namespace ErisSystem.Services.Contracts
{
    using ErisSystem.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IImagesService
    {
        Task<int> Add(byte[] imageData, string extension, string userId);

        IQueryable<Image> GetAll();

        Task<byte[]> GetUserImage(string userId);
    }
}