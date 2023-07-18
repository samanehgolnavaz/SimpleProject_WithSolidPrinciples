using SOLID_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Entities;

namespace SOLID_SRP
{
    public class InputParser
    {
        public List<SOLID_Entities.Pesron> ParseInput(string input)
        {
            string[] personRead = input.Split('\n');
            List<SOLID_Entities.Pesron> people = new List<SOLID_Entities.Pesron>();

            foreach (var item in personRead)
            {
                string[] personData = item.Split(',');
                SOLID_Entities.Pesron person = new SOLID_Entities.Pesron()
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
