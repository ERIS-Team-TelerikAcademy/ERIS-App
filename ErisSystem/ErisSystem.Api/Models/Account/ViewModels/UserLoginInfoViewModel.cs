namespace ErisSystem.Api.Models.Account.ViewModels
{
    using System.Collections.Generic;

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}