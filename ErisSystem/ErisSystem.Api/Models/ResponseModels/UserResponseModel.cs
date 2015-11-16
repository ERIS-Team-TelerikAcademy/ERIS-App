namespace ErisSystem.Api.Models.ResponseModels
{
    using System;

    public class UserResponseModel
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AboutMe { get; set; }

        public bool Gender { get; set; }
    }
}