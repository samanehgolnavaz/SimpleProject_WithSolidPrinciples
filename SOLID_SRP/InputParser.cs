using SOLID_Entities;

namespace SOLID_SRP
{
    public class InputParser
    {
        public List<Pesron> ParseInput(string input)
        {
            string[] personRead = input.Split('\n');
            List<Pesron> people = new List<Pesron>();

            foreach (var item in personRead)
            {
                string[] personData = item.Split(',');
                Pesron person = new Pesron()
                {
                    Id = int.Parse(personData[0]),
                    Name = personData[1],
                    Family = personData[2],
                    BirthDate = DateTime.Parse(personData[3])
                };
                people.Add(person);
            }

            return people;
        }
    }
}
