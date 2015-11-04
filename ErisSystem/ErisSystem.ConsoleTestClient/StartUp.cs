namespace ErisSystem.ConsoleTestClient
{
    using System.Data.Entity;

    using ErisSystem.Data;
    using Data.Migrations;
    using System.Linq;
    using Models;

    class StartUp
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ErisSystemContext, Configuration>());
            var db = new ErisSystemContext();

            var testUser = new User();
            testUser.AboutMe = "Thug life";
            testUser.FirstName = "Ice P";
            testUser.LastName = "3OG";
            testUser.DateOfBirth = new System.DateTime(1999, 01, 01);

            var testUser2 = new User();
            testUser.AboutMe = "Gangsta Gangsta";
            testUser.FirstName = "Ice T";
            testUser.LastName = "3OG";
            testUser.DateOfBirth = new System.DateTime(1958, 02, 16);

            var testFirendship = new Friendship();

            testFirendship.FirstUser = testUser;
            testFirendship.SecondUser = testUser2;
            testFirendship.IsApproved = true;


            db.SaveChanges();
        }
    }
}
