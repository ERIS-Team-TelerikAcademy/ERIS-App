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


            var city = new City();
            city.Name = "Detroit";

            db.Cities.AddOrUpdate(city);

            var country = new Country();
            country.Name = "USA";

            db.Countries.AddOrUpdate(country);

            var location = new Location();
            location.Country = country;
            location.City = city;
            location.Street = "1st";

            db.Locations.AddOrUpdate(location);

            var user = new User();
            user.AboutMe = "Thug life";
            user.FirstName = "Ice P";
            user.LastName = "3OG";
            user.Location = location;
            user.DateOfBirth = date;

            db.Users.AddOrUpdate(user);

            var user2 = new User();
            user2.AboutMe = "Gangsta Gangsta";
            user2.FirstName = "Ice T";
            user2.LastName = "3OG";
            user2.Location = location;
            user2.DateOfBirth = date;

            db.Users.AddOrUpdate(user2);

            var testFirendship = new Friendship();

            testFirendship.FirstUser = user;
            testFirendship.SecondUser = user2;
            testFirendship.IsApproved = true;

            db.Friendships.AddOrUpdate(testFirendship);


            db.SaveChanges();
        }
    }
}
