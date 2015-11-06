namespace ErisSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Client
    {
        private DateTime registrationDate;

        public Client()
        {
            this.RegistrationDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string NickName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RegistrationDate { get; set; }
    }
}
