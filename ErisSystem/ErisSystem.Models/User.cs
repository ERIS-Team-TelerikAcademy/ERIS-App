﻿namespace ErisSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Image> images;

        private ICollection<Country> countriesOfOperation;

        private DateTime registrationDate;

        public User()
        {
            this.images = new HashSet<Image>();
            this.countriesOfOperation = new HashSet<Country>();
            this.RegistrationDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(20)]
        public string Nickname { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

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
    }
}