namespace ErisSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class HitmanRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,5)]
        public double Rating { get; set; }

        [Required]
        public int HitmanId { get; set; }

        public Hitman Hitman { get; set; }

        public int ClientId { get; set; } //// So that after a client has given a rating he cant do it again for the same hitman(cant spam ranks well can register many times and spam but...shit)

        public virtual Client Client { get; set; }
    }
}
