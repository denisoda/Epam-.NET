using System.Collections.Generic;
using System.Xml.Linq;

namespace ExportToXML.Interface.Interfaces
{
    public interface IXMLConverter
    {
        XDocument Create(IEnumerable<string> source);
    }
}
