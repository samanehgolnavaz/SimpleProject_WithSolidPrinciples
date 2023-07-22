using SOLID_Entities;
using Newtonsoft.Json;
using System.Globalization;

namespace SOLID_WithOutSOLID_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, @"InputDocs\Person.csv");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, @"OutputDocs\Person.json");
            string input;

            using (FileStream stream = File.OpenRead(sourceFileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                input = reader.ReadToEnd();
            }

            string[] personRead = input.Split('\n');
            List<Pesron> people = new List<Pesron>();
            foreach (var item in personRead)
            {
                string[] personData = input.Split(',');
                Pesron person = new Pesron()
                {
                    Id = Convert.ToInt32(personData[0]),
                    Name = personData[1],
                    Family = personData[2],
                    // BirthDate = DateTime.Parse(personData[3])
                    BirthDate = DateTime.ParseExact(personData[3], "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };
                people.Add(person);
            }

            var serializedPeople = JsonConvert
                .SerializeObject(people);
            using (FileStream stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(serializedPeople);
                sw.Close();
            }


        }
    }
}