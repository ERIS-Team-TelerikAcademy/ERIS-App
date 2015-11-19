namespace ErisSystem.Tests.Setup
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Api.Models.ResponseModels;
    using Models;
    using Api;

    using MyTested.WebApi;
    using AutoMapper;

    [TestClass]
    public class Init
    {
        private static ResponseModelFactory modelFactory;

        [AssemblyInitialize]
        public static void Initialize(TestContext cont)
        {
            modelFactory = new ResponseModelFactory();

            modelFactory.MapBothWays<Country, CountryResponseModel>();
            modelFactory.MapBothWays<UserRating, HitmanRatingResponseModel>();
            modelFactory.MapBothWays<Image, ImageResponseModel>();
            modelFactory.MapBothWays<User, UserResponseModel>();
            modelFactory.MapBothWays<UserRating, UserRatingResponseModel>();

            Mapper.CreateMap<Contract, ContractResponseModel>()
                .ForMember(c => c.HitmanId, opts => opts.MapFrom(c => c.HitmanId))
                .ForMember(c => c.ClientId, opts => opts.MapFrom(c => c.ClientId))
                .ForMember(c => c.Status, opts => opts.MapFrom(c => (int)c.Status))
                .ForMember(c => c.HitStatus, opts => opts.MapFrom(c => (int)c.HitStatus));

            MyWebApi.IsRegisteredWith(WebApiConfig.Register);
        }

    }
}
