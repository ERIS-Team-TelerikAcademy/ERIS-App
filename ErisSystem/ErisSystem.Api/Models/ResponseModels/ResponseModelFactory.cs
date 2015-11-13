namespace ErisSystem.Api.Models.ResponseModels
{
    using System;
    using System.Linq.Expressions;
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

        public void MapCustom<S, D>(Expression<Func<S, object>> destination,  Action<IMemberConfigurationExpression<D>> action)
        {
            Mapper.CreateMap<D, S>().ForMember(destination, action);
        }
    }
}