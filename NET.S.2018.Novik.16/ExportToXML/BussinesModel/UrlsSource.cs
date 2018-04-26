using System;
using System.Collections.Generic;
using ExportToXML.Interface.Interfaces;
using System.IO;


namespace ExportToXML.BussinesModel
{
    public class UrlsSource : IURLSource
    {
        #region Private fields

        private string _path;

        #endregion

        #region Constructors

        public UrlsSource()
            : this("source.txt")
        {
        }

        public UrlsSource(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"{nameof(path)} must be not empty or null");
            }

            this._path = path;
        }

        #endregion

        #region Public methods

        public IEnumerable<string> GetRows()
        {
            List<string> result = new List<string>();
            using (TextReader reader = new StreamReader(File.Open(this._path, FileMode.Open)))
            {
                while (reader.Peek() != -1)
                {
                    result.Add(reader.ReadLine());
                }
            }

            return result;
        }

        #endregion
    }
}
