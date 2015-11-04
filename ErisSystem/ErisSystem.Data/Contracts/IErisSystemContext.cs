namespace ErisSystem.Data
{
    using System.Data.Entity;
    using ErisSystem.Models;

    public interface IErisSystemContext
    {
        IDbSet<User> Users { get; set; }
    }
}
