namespace ErisSystem.Api.Models.ResponseModels
{
    public interface IResponseModelFactory
    {
        R Get<R>(object model);
        void Map<S, D>();
        void MapBothWays<S, D>();
    }
}