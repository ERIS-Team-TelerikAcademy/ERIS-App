namespace ErisSystem.Api.Models.ResponseModels
{
    using AutoMapper;

    public class ResponseModelFactory : IResponseModelFactory
    {
        public void Map<S, D>()
        {
            Mapper.CreateMap<S, D>();
        }

        public void MapBothWays<S, D>()
        {
            Mapper.CreateMap<S, D>();
            Mapper.CreateMap<D, S>();
        }

        public R Get<R>(object model)
        {
            return Mapper.Map<R>(model);
        }
    }
}