namespace ErisSystem.Api.Models.ResponseModels
{
    using System;

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