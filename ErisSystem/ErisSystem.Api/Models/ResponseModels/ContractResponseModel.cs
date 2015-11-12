using System;

namespace ErisSystem.Api.Models.ResponseModels
{
    public class ContractResponseModel
    {
        public int Id { get; set; }

        public int HitmanId { get; set; }

        public int ClientId { get; set; }

        public int Status { get; set; }

        public int HitStatus { get; set; }

        public DateTime Deadline { get; set; }
    }
}