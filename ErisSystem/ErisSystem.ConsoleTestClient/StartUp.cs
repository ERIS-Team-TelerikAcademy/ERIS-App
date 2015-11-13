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

            Importer.ImportCountries();

            var db = new ErisSystemContext();

            var date = new DateTime(1991, 01, 01);

            var country = db.Countries.Find(3);

            var hitman = new Hitman();
            hitman.AboutMe = "Thug life";
            hitman.Nickname = "BaiIvan";
            hitman.Password = "Guest";
            hitman.DateOfBirth = date;
            hitman.CountriesOfOperation.Add(country);
           

            db.Hitmen.AddOrUpdate(hitman);
            db.SaveChanges();

            var client = new Client();
            client.Nickname = "SomeGuy";
            client.Password = "asjdfiubdfjabfjaasdfasd ";
            db.Clients.AddOrUpdate(client);
            db.SaveChanges();

            var connection = new Contract();
            connection.Hitman = hitman;
            connection.Client = client;
            connection.Deadline = new DateTime(2015,12,12);

            db.Contracts.AddOrUpdate(connection);

            var rating = new HitmanRating();
            rating.Client = client;
            rating.Hitman = hitman;
            rating.Rating = 4;

            db.HitmanRatings.AddOrUpdate(rating);

            db.SaveChanges();


            var repositoryTest = new EfGenericRepository<Hitman>(db);

            var hitmen = repositoryTest.All();

            foreach (var x in hitmen)
            {
                Console.WriteLine(x.Nickname);
                Console.WriteLine(x.Gender);
                Console.WriteLine(x.AboutMe);
                Console.WriteLine(x.DateOfBirth);
            }

            var ratingOfHitman = db.HitmanRatings.Where(x => x.HitmanId == hitman.Id).ToList();

            foreach (var rate in ratingOfHitman)
            {
                Console.WriteLine(rate.Rating);
            }
        }
    }
}
