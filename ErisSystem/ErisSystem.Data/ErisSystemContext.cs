namespace ErisSystem.Data
{
    using System.Data.Entity;
    using ErisSystem.Models;

    public class ErisSystemContext : DbContext, IErisSystemContext
    {
        public ErisSystemContext()
            :base("name=ErisSystemContext")
        {

        }

        public IDbSet<User> Users { get; set; }
    }
}
