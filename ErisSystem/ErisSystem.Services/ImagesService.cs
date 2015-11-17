namespace ErisSystem.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO;

    using Contracts;
    using Models;
    using Data;

    using Dropbox.Api;
    using Dropbox.Api.Files;

    public class ImagesService : IImagesService
    {
        private const string DropboxImagesFolderName = "/images";
        private const string DropboxAuthKey = "11KXkFS93BAAAAAAAAAAB9G5M6Yq6AHEsIHUjL8MJF5w_oaph2IbtlJu4VzgIyTH";

        private readonly IRepository<Image> images;
        private readonly IRepository<User> users;
        private readonly DropboxClient dropboxClient;

        public ImagesService(IRepository<Image> images, IRepository<User> users, DropboxClient dropboxClient)
        {
            this.images = images;
            this.users = users;
            this.dropboxClient = dropboxClient;
        }

        public async Task<int> Add(byte[] imageData, string extension, string userId)
        {
            var currentUser = this.users
                    .All()
                    .FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
            {
                throw new ArgumentException("Invalid user!");
            }

            var image = new Image()
            {
                Name = currentUser.UserName,
                Extension = extension,
                UserId = userId
            };

            await UploadImageForUser(currentUser.UserName, imageData, extension);

            this.images.Add(image);
            this.images.SaveChanges();

            return image.Id;
        }

        public IQueryable<Image> GetAll()
        {
            return this.images.All();
        }

        public async Task<byte[]> GetUserImage(string userId)
        {
            var currentUser = this.users
                    .All()
                    .FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
            {
                throw new ArgumentException("Invalid user!");
            }

            return await DownloadImageForUser(currentUser.UserName);
        }

        private async Task UploadImageForUser(string username, byte[] image, string extension)
        {
            using (MemoryStream memStream = new MemoryStream(image))
            {
                await this.dropboxClient.Files.UploadAsync(
                    string.Format("{0}/{1}.{2}", DropboxImagesFolderName, username, extension),
                    WriteMode.Overwrite.Instance,
                    body: memStream);
            }
        }

        private async Task<byte[]> DownloadImageForUser(string username)
        {
            var fileList = await this.dropboxClient.Files.ListFolderAsync(DropboxImagesFolderName);
            var fileItem = fileList.Entries.Where(i => i.IsFile &&
                                i.Name.Substring(0, i.Name.LastIndexOf('.')) == username)
                                .SingleOrDefault();

            using (var response = await this.dropboxClient.Files.DownloadAsync(string.Format("{0}/{1}", DropboxImagesFolderName, fileItem.Name)))
            {
                return await response.GetContentAsByteArrayAsync();
            }
        }
    }
}