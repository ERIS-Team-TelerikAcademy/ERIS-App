namespace ErisSystem.Tests.Setup.DummyObjects
{
    using System;
    using System.Collections.Generic;

    using Services;
    using Services.Contracts;

    using Dropbox.Api;

    public static class DummyServices
    {
        public static ICountriesService GetDummyCountriesService()
        {
            return new CountriesService(DummyRepositories.DummyCountriesRepository());
        }

        public static IUsersRatingsService GetDummyUserRatingsService()
        {
            return new UsersRatingService(DummyRepositories.DummyUserRatingsRepository());
        }

        internal static IContractsService GetDummyContractsService()
        {
            return new ContractsService(DummyRepositories.DummyContractsRepository(), DummyRepositories.DummyHitmenRepository());
        }

        public static IImagesService GetDummyImagesService()
        {
            return new ImagesService(
                DummyRepositories.DummyImagesRepository(),
                DummyRepositories.DummyHitmenRepository(),
                new DropboxClient("rRbWGOFRsGAAAAAAAAAABs8x29IZ2uajqNU4mtZRAIU1qrxcUPM3Ox3C9DUhnW1l"));
        }
    }
}
