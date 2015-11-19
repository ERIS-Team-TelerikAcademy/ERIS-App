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

        public string TargetName { get; set; }

        public string Location { get; set; }

        public DateTime Deadline { get; set; }
    }
}