﻿namespace ErisSystem.Api
{
    using System.Web;
    using System.Web.Http;
    using AutoMapper;
    using Models.ResponseModels;
    using ErisSystem.Models;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var modelFactory = new ResponseModelFactory();

            modelFactory.MapBothWays<Client, ClientResponseModel>();
            modelFactory.MapBothWays<Contract, ContractResponseModel>();
            modelFactory.MapBothWays<Country, CountryResponseModel>();
            modelFactory.MapBothWays<HitmanRating, HitmanRatingResponseModel>();
            modelFactory.MapBothWays<Image, ImageResponseModel>();
            modelFactory.MapBothWays<Hitman, HitmanResponseModel>();
        }
    }
}
