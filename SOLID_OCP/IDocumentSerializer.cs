using Newtonsoft.Json;
using SOLID_Entities;

namespace SOLID_OCP
{
    public interface IDocumentSerializer
    {
        string Serialize(List<Pesron> doc);
    }
    public class JasonDocumentSerializer : IDocumentSerializer
    {
        public string Serialize(List<Pesron> doc)
        {
            return JsonConvert.SerializeObject(doc);
        }
    }
    public class CamleCaseJsonSerializer : IDocumentSerializer
    {
        public string Serialize(List<Pesron> doc)
        {
            return new CamleCaseJsonSerializer().Serialize(doc);
        }
    }
}
