namespace ErisSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;

    public class User : IdentityUser
    {
        private ICollection<Image> images;

        private ICollection<Country> countriesOfOperation;

        public User()
        {
            this.images = new HashSet<Image>();
            this.countriesOfOperation = new HashSet<Country>();
            this.RegistrationDate = DateTime.Now;
        }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RegistrationDate { get; set; }

        [MaxLength(250)]
        public string AboutMe { get; set; }

        public bool Gender { get; set; }

        public bool IsWorking { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Country> CountriesOfOperation
        {
            get { return this.countriesOfOperation; }
            set { this.countriesOfOperation = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
