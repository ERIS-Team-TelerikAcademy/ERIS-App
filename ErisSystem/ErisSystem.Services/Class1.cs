using ErisSystem.Data;
using ErisSystem.Data.Repositories;
using ErisSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErisSystem.Services
{
    public class Class1
    {
        static void Main()
        {
            var ctx = new ErisSystemContext();
            var hitmenDb = new EfGenericRepository<Hitman>(ctx);
            var hitmen = new HitmenServices(hitmenDb);

            ///test.Add("OG OG OG ", "TERANCE DJAKONS", Models.Enumerators.Genders.Male, null, null);

            //var hitmen = test.GetAll();

            //foreach (var item in hitmen)
            //{
            //    Console.WriteLine(item.NickName + item.RegistrationDate);
            //}

            var clientDb = new EfGenericRepository<Client>(ctx);

            var clients = new ClientsServices(clientDb);

            //clients.Add("Test");
            //clients.Add("Test2");
            //clients.Add("Test3");

            //foreach (var item in clients.GetAll())
            //{
            //    Console.WriteLine(item.NickName);
            //}

            //Lets not have delete for anything its horrible stupid FK constrains f*************

            //var hitman = test.GetById(0);
            //Console.WriteLine(hitman);

            //foreach (var item in test.GetAll())      Crashes with some stupid error 
            //{
            //    test.Delete(item); 
            //}

            //var testetst = clients.GetById(1);
            //var clientDb1 = new EfGenericRepository<Client>(new ErisSystemContext());

            //var clients1 = new ClientsServices(clientDb);
            //clients1.Delete(testetst);

            //var countryDb = new EfGenericRepository<Country>(new ErisSystemContext());

            //var countries = new CountriesServices(countryDb);

            //foreach (var item in countries.GetAll())
            //{
            //    Console.WriteLine(item.Name);

            //}

            //var ratingDb = new EfGenericRepository<HitmanRating>(new ErisSystemContext());

            //var ratings = new HitmenRatingServices(ratingDb);

            //foreach (var item in ratings.GetAll())
            //{
            //    Console.WriteLine(item.Rating + " " + item.HitmanId);
            //}

            var contractsDb = new EfGenericRepository<Contract>(ctx);
            var contracts = new ContractsService(contractsDb, clientDb, hitmenDb);

            foreach (var item in contracts.GetAll())
            {
                Console.WriteLine(item.Deadline);
            }

            contracts.Add(hitmen.GetAll().FirstOrDefault().Nickname, clients.GetAll().FirstOrDefault().Nickname, DateTime.Now);
        }
    }
}
