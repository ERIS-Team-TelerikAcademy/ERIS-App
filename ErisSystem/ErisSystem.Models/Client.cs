namespace ErisSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Client
    {
        private DateTime registrationDate;

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string NickName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RegistrationDate
        {
            get { return this.registrationDate; }
            set { this.registrationDate = DateTime.Now; }
        }
    }
}
