namespace ErisSystem.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Common.Helpers.Dropbox;
    using Models;
    
    public interface IImagesService
    {
        Task<int> Add(string name, string extension, string userId, byte[] imageData);

        IQueryable<Image> All();

        Task<IList<DropBoxImageModel>> GetUserImages(string userId);

        Task Delete(int id);
    }
}