using SOLID_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SOLID_OCP
{
    public class InputParser
    {
        public virtual List<Pesron> ParseInput(string input)
        {
            string[] personRead = input.Split('\n');
            List<Pesron> people = new List<Pesron>();

            foreach (var item in personRead)
            {
                string[] personData = item.Split(',');
                Pesron student = new Pesron()
                {
                    Id = int.Parse(personData[0]),
                    Name = personData[1],
                    Family = personData[2],
                    BirthDate = DateTime.Parse(personData[3])
                };
                people.Add(student);
            }

            return people;
        }
    }
    public class XmlInputParser : InputParser
    {
        public override List<Pesron> ParseInput(string input)
        {
            try
            {
                var xDoc = XDocument.Parse(input);
                IEnumerable<XElement> rootElements;
                rootElements = xDoc.Root.Elements();
                Pesron[] people = new Pesron[rootElements.Count()];
                for (int index = 0; index < people.Length; index++)
                {
                    var xPerson = rootElements.ElementAt(index).Elements().ToArray();
                    Pesron student = new Pesron()
                    {
                        Id = int.Parse(xPerson[3].Value),
                        Name = xPerson[1].Value,
                        Family = xPerson[2].Value,
                        BirthDate = DateTime.Parse(xPerson[0].Value)
                    };
                    people[index] = student;
                }
                return people.ToList();
            }
            catch (Exception)
            {
                throw new InvalidInputFormatException();
            }
        }
    }

}
