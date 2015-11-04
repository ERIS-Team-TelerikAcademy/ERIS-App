namespace ErisSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Image> images;

        public User()
        {
            this.images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(250)]
        public string AboutMe { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
