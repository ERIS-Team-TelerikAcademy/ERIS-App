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
            var db = new ErisSystemContext();

            var date = new DateTime(1991, 01, 01);

            var country = new Country();
            country.Name = "USA";

            db.Countries.AddOrUpdate(country);
            db.SaveChanges();


            var hitman = new Hitman();
            hitman.AboutMe = "Thug life";
            hitman.NickName = "Killa";
            hitman.DateOfBirth = date;
            hitman.CountriesOfOperation.Add(country);
           

            db.Hitmen.AddOrUpdate(hitman);
            db.SaveChanges();

            var client = new Client();
            client.NickName = "SomeGuy";
            db.Clients.AddOrUpdate(client);
            db.SaveChanges();

            var connection = new Contract();
            connection.Hitman = hitman;
            connection.Client = client;
            connection.DeadLine = new DateTime(2015,12,12);

            db.Contracts.AddOrUpdate(connection);

            db.SaveChanges();


            var repositoryTest = new EfGenericRepository<Hitman>(db);

            var hitmen = repositoryTest.All();

            foreach (var x in hitmen)
            {
                Console.WriteLine(x.NickName);
                Console.WriteLine(x.Gender);
                Console.WriteLine(x.AboutMe);
                Console.WriteLine(x.DateOfBirth);
            }
        }
    }
}
