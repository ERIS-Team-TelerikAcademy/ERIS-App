namespace ErisSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,5)]
        public int Rating { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public int RatingUserId { get; set; } 

        public virtual User RatingUser { get; set; }
    }
}
