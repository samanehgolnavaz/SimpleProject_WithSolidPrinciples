using SOLID_SRP;

namespace SOLID_SRP
{
     class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                var sourceFileName = Path.Combine(Directory.GetCurrentDirectory(), @"/InputDocs/Person.CSV");
                var targetFileName = Path.Combine(Directory.GetCurrentDirectory(), @"OutputDocs/Person.Json");
                var fileFormatConvertor = new FileFormatConvertor();
                if (!fileFormatConvertor.ConvertFormat(sourceFileName, targetFileName))
                {
                    Console.WriteLine("Conversion Failed");
                    Console.ReadKey();

                }

            }
        }
    }
}