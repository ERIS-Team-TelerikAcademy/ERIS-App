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
    }
}
