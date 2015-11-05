namespace ErisSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ErisSystem.Models;

    public interface IErisSystemContext
    {
        IDbSet<Hitman> Hitmen { get; set; }

        IDbSet<Connection> Connections { get; set; }

        IDbSet<Location> Locations { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Client> Clients { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();

    }
}
