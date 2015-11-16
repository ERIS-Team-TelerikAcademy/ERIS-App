namespace ErisSystem.Api.Controllers
{
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Models.ResponseModels;
    using Services.Contracts;

    [RoutePrefix("api/Countries")]
    public class CountriesController : ApiController
    {
        private readonly ICountriesService countries;

        public CountriesController(ICountriesService countries)
        {
            this.countries = countries;
        }

        public IHttpActionResult Get()
        {
            var countries = this.countries.GetAll().ProjectTo<CountryResponseModel>();

            return this.Ok(countries);
        }
    }
}