namespace ErisSystem.Api.Models.ResponseModels
{
    using ErisSystem.Models;
    using System;
    using System.Linq;

    public class UserResponseModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AboutMe { get; set; }

        public bool Gender { get; set; }

        public bool IsWorking { get; set; }
    }
}