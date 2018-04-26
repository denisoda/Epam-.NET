using System;
using System.Collections.Generic;
using ExportToXML.Interface.Interfaces;
using System.IO;

namespace ExportToXML.BussinesModel
{
    /// <summary>
    /// Provides methods to get URL from file.
    /// </summary>
    public class UrlFromTextFile : IURLSource
    {
        #region Private fields

        private string _path;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlFromTextFile"/> class.
        /// </summary>
        public UrlFromTextFile()
            : this("source.txt")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlFromTextFile"/> class.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public UrlFromTextFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"{nameof(path)} must be not empty or null");
            }

            this._path = path;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the set of URL.
        /// </summary>
        /// <returns>set of URL.</returns>
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
