using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ExportToXML.Interface.Interfaces;

namespace ExportToXML.BussinesModel
{
    public class XmlSaver : IXMLSaver
    {
        #region Private fields

        private string _path;

        #endregion

        #region Constructors

        public XmlSaver()
            : this("result.xml")
        {
        }

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

        public void Save(XDocument document)
        {
            document.Save(this._path);
        }

        #endregion
    }
}
