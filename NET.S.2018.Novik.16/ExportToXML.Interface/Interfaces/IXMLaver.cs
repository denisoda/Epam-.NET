using System.Xml.Linq;

namespace ExportToXML.Interface.Interfaces
{
    public interface IXMLSaver
    {
        void Save(XDocument document);
    }
}