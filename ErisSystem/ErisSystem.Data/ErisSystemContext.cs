namespace ErisSystem.Data
{
    using System;
    using System.Data.Entity;

    using ErisSystem.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ErisSystemContext : DbContext, IErisSystemContext
    {
        public ErisSystemContext()
            :base("ErisSystemContext")
        {

        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Contract> Contracts { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<UserRating> HitmanRatings { get; set; }

        public static ErisSystemContext Create()
        {
            return new ErisSystemContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
