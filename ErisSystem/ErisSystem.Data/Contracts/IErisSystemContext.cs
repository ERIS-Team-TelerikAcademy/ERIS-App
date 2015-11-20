namespace ErisSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ErisSystem.Models;

    public interface IErisSystemContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Contract> Contracts { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<UserRating> HitmanRatings { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
