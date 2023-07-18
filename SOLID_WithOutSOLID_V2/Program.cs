using System;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SOLID_Entities;
namespace SOLID_WithOutSOLID_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, @"InputDocs\Person.csv");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, @"OutputDocs\Person.json");
            var input = GetInput(sourceFileName);
            var people= GetPeople(input);
            var serializedPeople = Program.serializedPeople(people);
            PersistPeople(serializedPeople,targetFileName);
        }

        private static List<SOLID_Entities.Pesron> GetPeople(string input)
        {
            string[] personRead = input.Split('\n');
            List<SOLID_Entities.Pesron> people = new List<SOLID_Entities.Pesron>();
            foreach (var item in personRead)
            {
                string[] personData = input.Split(',');
                SOLID_Entities.Pesron person = new SOLID_Entities.Pesron()
                {
                    Id = Convert.ToInt32(personData[0]),
                    Name = personData[1],
                    Family = personData[2],
                    // BirthDate = DateTime.Parse(personData[3])
                    BirthDate = DateTime.ParseExact(personData[3], "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };
                people.Add(person);
            }
            return people;

        }

        private static string GetInput(string sourceFileName)
        {
            string input;

            using (FileStream stream = File.OpenRead(sourceFileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                input = reader.ReadToEnd();
            }
            return input;
        }

        private static void PersistPeople(Object serializedPeople , string targetFileName)
        {
            using (FileStream stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(serializedPeople);
                sw.Close();
            }
        }

        private static string serializedPeople(List<SOLID_Entities.Pesron> people)
        {
            return JsonConvert
                .SerializeObject(people);
        }
    }
}