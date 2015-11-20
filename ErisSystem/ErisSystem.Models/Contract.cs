namespace ErisSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enumerators;

    public class Contract
    {
        public Contract()
        {
            this.Status = ConnectionStatus.Pending;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string HitmanId { get; set; }

        public virtual User Hitman { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual User Client { get; set; }

        public ConnectionStatus Status { get; set; }

        [MaxLength(50)]
        public string TargetName { get; set; }

        [MaxLength(250)]
        public string Location { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Deadline { get; set; }
    }
}
