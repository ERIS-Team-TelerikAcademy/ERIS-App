namespace ErisSystem.Api
{
    using System.Web;
    using System.Web.Http;
    using Models.ResponseModels;
    using ErisSystem.Models;
    using AutoMapper;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var modelFactory = new ResponseModelFactory();

            modelFactory.MapBothWays<Country, CountryResponseModel>();
            modelFactory.MapBothWays<UserRating, HitmanRatingResponseModel>();
            modelFactory.MapBothWays<Image, ImageResponseModel>();
            modelFactory.MapBothWays<User, UserResponseModel>();
            modelFactory.MapBothWays<UserRating, UserRatingResponseModel>();

            Mapper.CreateMap<Contract, ContractResponseModel>()
                .ForMember(c => c.HitmanId, opts => opts.MapFrom(c => c.HitmanId))
                .ForMember(c => c.ClientId, opts => opts.MapFrom(c => c.ClientId))
                .ForMember(c => c.Status, opts => opts.MapFrom(c => (int)c.Status))
                .ForMember(c => c.TargetName, opts => opts.MapFrom(c => c.TargetName))
                .ForMember(c => c.Location, opts => opts.MapFrom(c => c.Location));
        }
    }
}
