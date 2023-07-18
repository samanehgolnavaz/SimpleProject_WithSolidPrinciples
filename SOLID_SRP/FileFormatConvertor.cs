using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
             input = _documentStorage.GetData(sourceFileName);
             var doc = _inputParser.ParseInput(input);
             var serializedDoc = _documentSerializer.Serilize(doc);
             _documentStorage.PersistDocument(serializedDoc,targetFileName);
             return true;

         }
    }
  
}
