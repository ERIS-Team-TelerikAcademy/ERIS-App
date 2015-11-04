namespace ErisSystem.Data
{
    using System;
    using System.Data.Entity;

    using ErisSystem.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ErisSystemContext : DbContext, IErisSystemContext
    {
        public ErisSystemContext()
            :base("name=ErisSystemContext")
        {

        }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; } 

        public IDbSet<Friendship> Friendships { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
