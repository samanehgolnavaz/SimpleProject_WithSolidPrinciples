namespace SOLID_SRP
{
    class FileFormatConvertor
     {
         private readonly DocumentStorage _documentStorage;
         private readonly DocumentSerializer _documentSerializer;
         private readonly InputParser _inputParser;

         public FileFormatConvertor()
         {
             _documentStorage=new DocumentStorage();
             _documentSerializer=new DocumentSerializer();
             _inputParser=new InputParser();
         }
         public bool ConvertFormat(string sourceFileName, string targetFileName)
         {
             string input;
             try
             {
                 input = _documentStorage.GetData(sourceFileName);
             }
             catch (FileNotFoundException)
             {
                 return false;
             }
             var doc = _inputParser.ParseInput(input);
             var serializedDoc = _documentSerializer.Serilize(doc);
             try
             {
                 _documentStorage.PersistDocument(serializedDoc, targetFileName);
             }
             catch (AccessViolationException)
             {
                 return false;
             }
             return true;

         }
    }
  
}
