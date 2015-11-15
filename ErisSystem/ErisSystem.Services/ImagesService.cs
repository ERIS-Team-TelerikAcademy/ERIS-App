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
        private const string DropboxImageLocationPathFormat = "/images/{0}.{1}";

        private readonly IRepository<Image> images;
        private readonly IRepository<User> users;
        private readonly DropboxClient dropboxClient;

        public ImagesService(IRepository<Image> images, IRepository<User> users, DropboxClient dropboxClient)
        {
            this.images = images;
            this.users = users;
            this.dropboxClient = dropboxClient;
        }

        public async Task<int> Add(byte[] imageData, string extension, int forUserId)
        {
            var currentUser = this.users
                    .All()
                    .FirstOrDefault(u => u.Id == forUserId);

            if (currentUser == null)
            {
                throw new ArgumentException("Invalid user!");
            }

            // Change to Nickname to UserName when integrated with built-in auth
            var image = new Image()
            {
                Name = currentUser.Nickname,
                Extension = extension,
                UserId = forUserId
            };

            await UploadImageForUser(currentUser.Nickname, imageData, extension);

            this.images.Add(image);
            this.images.SaveChanges();

            return image.Id;
        }

        public IQueryable<Image> GetAll()
        {
            return this.images.All();
        }

        private async Task UploadImageForUser(string username, byte[] image, string extension)
        {
            using (MemoryStream memStream = new MemoryStream(image))
            {
                await this.dropboxClient.Files.UploadAsync(
                    string.Format(DropboxImageLocationPathFormat, username, extension),
                    WriteMode.Overwrite.Instance,
                    body: memStream);
            }
        }
    }
}
