namespace ErisSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
