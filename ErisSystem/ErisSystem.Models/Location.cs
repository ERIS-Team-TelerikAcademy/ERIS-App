namespace ErisSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string Street { get; set; }

    }
}
