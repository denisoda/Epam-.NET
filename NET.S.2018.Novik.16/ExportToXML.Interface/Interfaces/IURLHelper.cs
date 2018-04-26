using System.Collections.Generic;

namespace ExportToXML.Interface.Interfaces
{
    public interface IURLHelper
    {
        string GetHost(string url);
        Dictionary<string, string> GetParameters(string url);
        IEnumerable<string> GetUri(string url);
        bool IsValid(string url);
    }
}