namespace ErisSystem.Tests.DummyObjects
{
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
    }
}
