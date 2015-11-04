namespace ErisSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(250)]
        public string AboutMe { get; set; }
    }
}
