namespace ErisSystem.ConsoleTestClient
{
    using System.Collections.ObjectModel;
    using System.IO;

    using Models;
    using Data;

    internal static class Importer
    {
        private const string PathToTxtFile = "../../ListOfCountries.txt";

        public static void ImportCountries()
        {
            var countries = GetCountries(PathToTxtFile);
            var db = new ErisSystemContext();

            foreach (var country in countries)
            {
                var currentCountry = new Country();
                currentCountry.Name = country;
                db.Countries.Add(currentCountry);
            }
            db.SaveChanges();
            db.Dispose();
        }


        private static Collection<string> GetCountries(string pathToFile)
        {
            var result = new Collection<string>();
            var reader = new StreamReader(pathToFile);

            while (!reader.EndOfStream)
            {
                var currentCountry = reader.ReadLine().Trim();
                result.Add(currentCountry);
            }

            reader.Dispose();

            return result;
        }
    }
}
