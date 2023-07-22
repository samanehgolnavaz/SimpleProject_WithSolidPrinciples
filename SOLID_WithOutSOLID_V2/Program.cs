using System.Globalization;
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
            var serializedPeople = Program.SerializedPeople(people);
            PersistPeople(serializedPeople,targetFileName);
        }

        private static List<Pesron> GetPeople(string input)
        {
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

        private static string SerializedPeople(List<Pesron> people)
        {
            return JsonConvert
                .SerializeObject(people);
        }
    }
}