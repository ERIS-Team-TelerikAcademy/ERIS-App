namespace ErisSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public class EfConfiguration : DbMigrationsConfiguration<ErisSystemContext>
    {           
        public EfConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
