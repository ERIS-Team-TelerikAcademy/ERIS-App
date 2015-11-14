namespace ErisSystem.ConsoleTestClient
{
    using System.Data.Entity;
    using Data.Migrations;
    using System.Linq;
    using Models;
    using System;

    using ErisSystem.Data;
    using System.Data.Entity.Migrations;
    using Data.Repositories;

    class StartUp
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ErisSystemContext, Configuration>());
            //Delete your db first if you have BaiIvan in there!
            Importer.ImportCountries();

            var db = new ErisSystemContext();

            var date = new DateTime(1991, 01, 01);

            var country = db.Countries.Find(3);

            var hitman = new User();
            hitman.AboutMe = "Thug life";
            hitman.Nickname = "Bono";
            hitman.Password = "ASFADSFDEFE@#@$@$@ASDFAS";
            hitman.DateOfBirth = date;
            hitman.CountriesOfOperation.Add(country);
           

            db.Users.AddOrUpdate(hitman);
            db.SaveChanges();



            var repositoryTest = new EfGenericRepository<User>(db);

            var hitmen = repositoryTest.All();

            foreach (var x in hitmen)
            {
                Console.WriteLine(x.Nickname);
                Console.WriteLine(x.Gender);
                Console.WriteLine(x.AboutMe);
                Console.WriteLine(x.DateOfBirth);
            }

        }
    }
}
