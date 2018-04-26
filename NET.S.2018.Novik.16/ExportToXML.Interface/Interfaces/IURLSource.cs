using System.Collections.Generic;

namespace ExportToXML.Interface.Interfaces
{
    public interface IURLSource
    {
        IEnumerable<string> GetRows();
    }
}