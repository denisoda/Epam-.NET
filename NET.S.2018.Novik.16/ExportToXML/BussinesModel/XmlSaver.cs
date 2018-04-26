using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ExportToXML.Interface.Interfaces;

namespace ExportToXML.BussinesModel
{
    /// <summary>
    /// Provides methods to save XML in the file.
    /// </summary>
    public class XmlSaver : IXMLSaver
    {
        #region Private fields

        private readonly string _path;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSaver"/> class.
        /// </summary>
        public XmlSaver()
            : this("result.xml")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSaver"/> class.
        /// </summary>
        /// <param name="path">Path to file.</param>
        public XmlSaver(string path)
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
        /// Saves <see cref="XDocument"/> in the file.
        /// </summary>
        /// <param name="document">XDocument to save.</param>
        public void Save(XDocument document)
        {
            document.Save(this._path);
        }

        #endregion
    }
}
