namespace ErisSystem.Services.Contracts
{
    using ErisSystem.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IImagesService
    {
        Task<int> Add(string name, string extension, string userId, byte[] imageData);

        IQueryable<Image> All();

        Task<IList<byte[]>> GetUserImages(string userId);

        Task Delete(int id);
    }
}