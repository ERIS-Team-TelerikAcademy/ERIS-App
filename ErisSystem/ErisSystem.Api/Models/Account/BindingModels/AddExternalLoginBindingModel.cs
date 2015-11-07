namespace ErisSystem.Api.Models.Account.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}