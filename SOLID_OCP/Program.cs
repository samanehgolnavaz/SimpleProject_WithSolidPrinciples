
namespace SOLID_OCP
{ class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, @"InputDocs\Person.csv");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, @"OutputDocs\Person.csv");
            var fileFormatConvertor = new FileFormatConvertor();
            sourceFileName = Path.Combine(Environment.CurrentDirectory, @"InputDocs\Person.xml");
            sourceFileName = "http://irtoya.com";
            if (!fileFormatConvertor.ConvertFormat(sourceFileName, targetFileName))
            {
                Console.WriteLine("Conversion Failed");
                Console.ReadKey();

            }

        }
    }
}