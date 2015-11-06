namespace ErisSystem.Models
{
    using Enumerators;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Hitman
    {
        private ICollection<Image> images;

        private ICollection<Country> countriesOfOperation;

        private DateTime registrationDate;

        public Hitman()
        {
            this.images = new HashSet<Image>();
            this.countriesOfOperation = new HashSet<Country>();
            this.RegistrationDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string NickName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RegistrationDate { get; set; }

        [MaxLength(250)]
        public string AboutMe { get; set; }

        public Genders Gender { get; set; }

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
    }
}
