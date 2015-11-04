namespace ErisSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        [Key]
        public int Id { get; set; }
        
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
