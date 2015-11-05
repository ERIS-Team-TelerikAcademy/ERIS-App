namespace ErisSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string NickName { get; set; }
    }
}
