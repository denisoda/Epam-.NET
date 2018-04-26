using System.Collections.Generic;
using ExportToXML.Interface.Interfaces;

namespace ExportToXML.BussinesModel
{
    public class UrlHelper : IURLHelper
    {
        public bool IsValid(string url)
        {
            return true;
        }

        public string GetHost(string url)
        {
            int startHostName = url.IndexOf('/', 0) + 2;
            int endHostName = url.IndexOf('/', startHostName);
            string value = url.Substring(startHostName, endHostName - startHostName);

            return value;
        }

        public IEnumerable<string> GetUri(string url)
        {
            const string separator = "/";
            List<string> result = new List<string>();
            int index = url.IndexOf(separator, url.IndexOf('/', 0) + 2) + 1;

            while (index != -1)
            {
                int secondIndex = url.IndexOfAny(new char[] { '/', '?' }, index);
                result.Add(url.Substring(index, secondIndex - index));
                index = secondIndex + 1;
                if (url.IndexOfAny(new char[] { '/', '?' }, index) == -1)
                {
                    break;
                }
            }

            return result;
        }

        public Dictionary<string,string> GetParameters(string url)
        {
            const string separator = "&";
            Dictionary<string, string> result = new Dictionary<string, string>();
            int index = url.LastIndexOf('?');
            int indexCompare = -1;

            while (index < url.Length && index != -1)
            {
                int secondIndex = url.IndexOf(separator, index);
                secondIndex = secondIndex == -1 ? url.Length : secondIndex - 1;
                indexCompare = url.IndexOf('=', index);
                string key = url.Substring(index + 1, indexCompare - index - 1);
                string value = url.Substring(indexCompare + 1, secondIndex - indexCompare - 1);
                result.Add(key, value);
                index = secondIndex;
            }

            return result;
        }
    }
}
