namespace ErisSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }

        [Required]
        public string HitmanId { get; set; }

        public User Hitman { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual User Client { get; set; }
    }
}
