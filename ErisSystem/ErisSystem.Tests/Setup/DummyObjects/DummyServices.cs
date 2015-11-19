namespace ErisSystem.Tests.Setup.DummyObjects
{
    using System;
    using System.Collections.Generic;
    using Services;
    using Services.Contracts;

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
    }
}
