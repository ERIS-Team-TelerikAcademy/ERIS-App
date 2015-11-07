namespace ErisSystem.Api.Models.Account.ViewModels
{
    using System.Collections.Generic;

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
}