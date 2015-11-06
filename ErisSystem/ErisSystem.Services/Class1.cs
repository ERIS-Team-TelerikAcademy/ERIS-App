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
            var db = new EfGenericRepository<Hitman>(new ErisSystemContext());
            var test = new HitmenServices(db);
            test.Add("OG OG OG ", "TERANCE DJAKONS", Models.Enumerators.Genders.Male, null, null);

            var hitmen = test.GetAll();

            foreach (var item in hitmen)
            {
                Console.WriteLine(item.NickName + item.RegistrationDate);
            }

            var hitman = test.GetById(0);
            Console.WriteLine(hitman);
        }
    }
}
