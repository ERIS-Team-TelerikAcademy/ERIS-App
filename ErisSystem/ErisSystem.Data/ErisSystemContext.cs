namespace ErisSystem.Data
{
    using System;
    using System.Data.Entity;

    using ErisSystem.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ErisSystemContext : IdentityDbContext<User>, IErisSystemContext
    {
        public ErisSystemContext()
            :base("name=ErisSystemContext")
        {

        }

        public IDbSet<Country> Countries { get; set; }

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
