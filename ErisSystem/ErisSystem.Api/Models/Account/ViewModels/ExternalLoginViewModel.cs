namespace ErisSystem.Api.Models.Account.ViewModels
{
    using System.Collections.Generic;

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }
}