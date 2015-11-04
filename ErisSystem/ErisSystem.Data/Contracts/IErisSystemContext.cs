namespace ErisSystem.Data
{
    using System.Data.Entity;

    using ErisSystem.Models;

    public interface IErisSystemContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Friendship> Friendships { get; set; }

        IDbSet<Location> Locations { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Image> Images { get; set; }
    }
}
