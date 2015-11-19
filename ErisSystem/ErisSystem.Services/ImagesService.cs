namespace ErisSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO;

    using Contracts;
    using Common.Helpers.Dropbox;
    using Models;
    using Data;

    using Dropbox.Api;
    using Dropbox.Api.Files;


    public class ImagesService : IImagesService
    {
        private const string DropboxImagesFolderName = "/images";

        private readonly IRepository<Image> images;
        private readonly IRepository<User> users;
        private readonly DropboxClient dropboxClient;

        public ImagesService(IRepository<Image> images, IRepository<User> users, DropboxClient dropboxClient)
        {
            this.images = images;
            this.users = users;
            this.dropboxClient = dropboxClient;
        }

        public async Task<int> Add(string name, string extension, string userId, byte[] imageData)
        {
            var currentUser = this.users
                    .All()
                    .FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
            {
                throw new ArgumentException("Invalid user specified.");
            }

            var image = new Image()
            {
                Name = name,
                Extension = extension,
                UserId = userId
            };

            await UploadImageForUser(name, extension, currentUser.UserName, imageData);

            this.images.Add(image);
            currentUser.Images.Add(image);

            this.images.SaveChanges();
            this.users.SaveChanges();

            return image.Id;
        }

        public IQueryable<Image> All()
        {
            return this.images.All();
        }

        public async Task<IList<DropBoxImageModel>> GetUserImages(string userId)
        {
            var currentUser = this.users
                    .All()
                    .FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
            {
                throw new ArgumentException("Invalid user!");
            }

            return await DownloadImagesForUser(currentUser.UserName);
        }

        private async Task UploadImageForUser(string name, string extension, string username, byte[] image)
        {
            using (MemoryStream memStream = new MemoryStream(image))
            {
                await this.dropboxClient.Files.UploadAsync(
                    string.Format("{0}/{1}/{2}.{3}", DropboxImagesFolderName, username, name, extension),
                    WriteMode.Overwrite.Instance,
                    body: memStream);
            }
        }

        private async Task<IList<DropBoxImageModel>> DownloadImagesForUser(string username)
        {
            ListFolderResult fileList = await this.dropboxClient.Files.ListFolderAsync(string.Format("{0}/{1}", DropboxImagesFolderName, username));

            if (fileList.Entries.Count == 0)
            {
                throw new InvalidOperationException("Invalid user specified or user has no images.");
            }

            var result = new List<DropBoxImageModel>();
            foreach (var imageFile in fileList.Entries)
            {
                using (var response = await this.dropboxClient.Files.DownloadAsync(string.Format("{0}/{1}/{2}", DropboxImagesFolderName, username, imageFile.Name)))
                {
                    byte[] data = await response.GetContentAsByteArrayAsync();
                    var currentImage = new DropBoxImageModel()
                    {
                        Data = data,
                        ImageName = imageFile.Name,
                        UserName = username
                    };

                    result.Add(currentImage);
                }
            }

            return result;
        }

        public async Task Delete(int id)
        {
            var image = this.images
                .All()
                .FirstOrDefault(i => i.Id == id);

            if (image == null)
            {
                throw new ArgumentOutOfRangeException("Invalid image id.");
            }

            await this.dropboxClient.Files.DeleteAsync(string.Format("{0}/{1}/{2}.{3}", DropboxImagesFolderName, image.User.UserName, image.Name, image.Extension));

            this.images.Delete(image);
            this.images.SaveChanges();
        }
    }
}