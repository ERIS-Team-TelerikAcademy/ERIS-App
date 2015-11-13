namespace ErisSystem.Api.Models.ResponseModels
{
    using System;
    using System.Linq.Expressions;
    using AutoMapper;

    public interface IResponseModelFactory
    {
        void Map<S, D>();

        void MapBothWays<S, D>();

        void MapCustom<S, D>(Expression<Func<S, object>> destination, Action<IMemberConfigurationExpression<D>> action);
    }
}