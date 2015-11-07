namespace ErisSystem.Api.Models.ResponseModels
{
    using System;

    public class HitmanResponseModel
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string AboutMe { get; set; }

        public int Gender { get; set; }


    }
}