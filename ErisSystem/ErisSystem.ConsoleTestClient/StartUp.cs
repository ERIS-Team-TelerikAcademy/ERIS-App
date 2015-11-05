namespace ErisSystem.ConsoleTestClient
{
    using System.Data.Entity;
    using Data.Migrations;
    using System.Linq;
    using Models;
    using System;

    using ErisSystem.Data;
    using System.Data.Entity.Migrations;

    class StartUp
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ErisSystemContext, Configuration>());
            var db = new ErisSystemContext();
            var date = new DateTime(1991, 01, 01);

            var country = new Country();
            country.Name = "USA";

            var city = new City();
            city.Name = "Detroit";
            city.Country = country;

            db.Cities.AddOrUpdate(city);
            db.Countries.AddOrUpdate(country);
            db.SaveChanges();

            var location = new Location();
            location.Country = country;
            location.City = city;
            location.Street = "1st";
            db.Locations.AddOrUpdate(location);
            db.SaveChanges();

            var hitman = new Hitman();
            hitman.AboutMe = "Thug life";
            hitman.NickName = "Killa";
            hitman.Location = location;
            hitman.DateOfBirth = date;
            hitman.CountriesOfOperation.Add(country);
            s
            db.Hitmen.AddOrUpdate(hitman);
            db.SaveChanges();

            var client = new Client();
            client.NickName = "SomeGuy";
            db.Clients.AddOrUpdate(client);
            db.SaveChanges();

            var connection = new Connection();
            connection.Hitman = hitman;
            connection.Client = client;
            connection.DeadLine = new DateTime(2015,12,12);
            connection.Location = location;
            connection.TargetName = "John";

            db.Connections.AddOrUpdate(connection);

            db.SaveChanges();
        }
    }
}
