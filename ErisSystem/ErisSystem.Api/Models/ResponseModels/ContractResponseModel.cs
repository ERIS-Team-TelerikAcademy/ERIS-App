namespace ErisSystem.Api.Models.ResponseModels
{
    using System;
    using AutoMapper;
    using ErisSystem.Models;
    using ErisSystem.Models.Enumerators;

    public class ContractResponseModel
    {
        public int Id { get; set; }

        public string HitmanId { get; set; }

        public string ClientId { get; set; }

        public int Status { get; set; }

        public int HitStatus { get; set; }

        public DateTime Deadline { get; set; }

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    //configuration.CreateMap<ContractResponseModel, Contract>()
        //    //    .ForMember(c => c.HitmanId, opts => opts.MapFrom(c => c.HitmanId))
        //    //    .ForMember(c => c.ClientId, opts => opts.MapFrom(c => c.ClientId))
        //    //    .ForMember(c => c.Status, opts => opts.MapFrom(c => (ConnectionStatus)c.Status))
        //    //    .ForMember(c => c.HitStatus, opts => opts.MapFrom(c => (HitStatus)c.HitStatus));

        //    configuration.CreateMap<Contract, ContractResponseModel>()
        //        .ForMember(c => c.HitmanId, opts => opts.MapFrom(c => c.HitmanId))
        //        .ForMember(c => c.ClientId, opts => opts.MapFrom(c => c.ClientId))
        //        .ForMember(c => c.Status, opts => opts.MapFrom(c => (int)c.Status))
        //        .ForMember(c => c.HitStatus, opts => opts.MapFrom(c => (int)c.HitStatus));
        //}
    }
}