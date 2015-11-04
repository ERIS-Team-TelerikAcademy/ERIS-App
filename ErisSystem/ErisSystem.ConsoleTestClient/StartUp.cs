namespace ErisSystem.ConsoleTestClient
{
    using System.Data.Entity;

    using ErisSystem.Data;
    using Data.Migrations;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ErisSystemContext, Configuration>());
            var db = new ErisSystemContext();
            db.Users.ToList();
            db.SaveChanges();
        }
    }
}
