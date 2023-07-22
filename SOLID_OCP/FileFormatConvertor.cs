namespace SOLID_OCP
{
    class FileFormatConvertor
    {
        private readonly InputParser _inputParser;
        private readonly IDocumentSerializer _documentSerializer;

        public FileFormatConvertor()
        {
            _documentSerializer =new JasonDocumentSerializer();
            _inputParser=new XmlInputParser();
        }
        public bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            string input;
            var documentStorage = GetDocumentStorage(sourceFileName);

            try
            {
                input = documentStorage.GetData(sourceFileName);
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            var doc = _inputParser.ParseInput(input);
            var serializedDoc = _documentSerializer.Serialize(doc);
            try
            {
                documentStorage.PersistDocument(serializedDoc, targetFileName);
            }
            catch (AccessViolationException)
            {
                return false;
            }
            return true;


        }
        private DocumentStorage GetDocumentStorage(string sourceFileName)
        {
            if (sourceFileName.StartsWith("http"))
                return new HttpInputRetriever();
            return new FileDocumentStorage();
        }
    }
}
