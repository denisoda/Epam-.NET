using System.Collections.Generic;
using System.Text.RegularExpressions;
using ExportToXML.Interface.Interfaces;

namespace ExportToXML.BussinesModel
{
    /// <summary>
    /// Provides methods to work with URL.
    /// </summary>
    public class UrlHelper : IURLHelper
    {
        #region Public methods

        /// <summary>
        /// Checks if the <paramref name="url"/> is valid.
        /// </summary>
        /// <param name="url">Url to check.</param>
        /// <returns>Bool.</returns>
        public bool IsValid(string url)
        {
            const string patternValidUrl = @"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$";
            return Regex.IsMatch(url, patternValidUrl);
        }

        /// <summary>
        /// Gets the host of the <paramref name="url"/>.
        /// </summary>
        /// <param name="url">Url.</param>
        /// <returns>The host of url as string.</returns>
        public string GetHost(string url)
        {
            int startHostName = url.IndexOf('/', 0) + 2;
            int endHostName = url.IndexOf('/', startHostName);
            string value = url.Substring(startHostName, endHostName - startHostName);

            return value;
        }

        /// <summary>
        /// Gets sequence of uri from <paramref name="url"/>.
        /// </summary>
        /// <param name="url">Url to extract uri.</param>
        /// <returns>Sequence of uri.</returns>
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

        /// <summary>
        /// Gets dictionary parameters from <paramref name="url"/> as key and value.
        /// </summary>
        /// <param name="url">Url to extract.</param>
        /// <returns>Dictionary parameters.</returns>
        public Dictionary<string, string> GetParameters(string url)
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

        #endregion
    }
}
