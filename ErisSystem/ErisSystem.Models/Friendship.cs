namespace ErisSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Friendship
    {

        public Friendship()
        {
            this.IsApproved = false;
        }

        [Key]
        public int Id { get; set; }

        public int FirstUserId { get; set; }

        public virtual User FirstUser { get; set; }

        public int SecondUserId { get; set; }

        public virtual User SecondUser { get; set; }

        public bool IsApproved { get; set; }

    }
}
