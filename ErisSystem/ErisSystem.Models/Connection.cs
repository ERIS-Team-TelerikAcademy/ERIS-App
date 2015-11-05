namespace ErisSystem.Models
{
    using Enumerators;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Connection
    {

        public Connection()
        {
            this.Status = ConnectionStatus.Pending;
            this.HitStatus = HitStatus.Pending;
        }

        [Key]
        public int Id { get; set; }

        public int HitmanId { get; set; }

        public virtual Hitman Hitman { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client{ get; set; }

        public ConnectionStatus Status { get; set; }

        public HitStatus HitStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DeadLine { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public string TargetName { get; set; }
    }
}
