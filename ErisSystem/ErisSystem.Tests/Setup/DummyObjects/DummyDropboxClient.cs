namespace ErisSystem.Tests.Setup.DummyObjects
{
    using Dropbox.Api;
    using Dropbox.Api.Files;
    using Dropbox.Api.Files.Routes;
    using Models;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DummyDropboxClient
    {
        internal static DropboxClient Create()
        {
            var filesRoutesMock = new Mock<FilesRoutes>();

            Dictionary<string, Stream> dropboxImages = new Dictionary<string, Stream>();

            filesRoutesMock
                .Setup(x => x.UploadAsync(It.IsAny<string>(), It.IsAny<WriteMode>(), false, null, false, It.IsAny<Stream>()))
                .Callback<string, WriteMode, bool, DateTime?, bool, Stream>((p, wm, ar, cm, mute, b) => dropboxImages.Add(p, b));

            List<Stream> images = new List<Stream>();

            filesRoutesMock
                .Setup(x => x.ListFolderAsync(It.IsAny<string>(), false, false))
                .Callback<string, bool, bool>(
                    (p, r, mi) => images = dropboxImages.Keys
                            .Where(k => k.StartsWith(p))
                            .Select(k => dropboxImages[k])
                            .ToList()
                    );

            // Pure bullshit.

            var mock = new Mock<DropboxClient>();
            return mock.Object;
        }
    }
}