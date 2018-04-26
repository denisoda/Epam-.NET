using System;
using System.Collections.Generic;
using System.Linq;
using ExportToXML.Interface.Interfaces;
using System.Xml.Linq;

namespace ExportToXML.BussinesModel
{
    /// <summary>
    /// Provides a method to transformation url into xml.
    /// </summary>
    public class ConverterURLtoXML : IXMLConverter
    {
        #region Private fields

        private ICustomeLogger logger;
        private IURLHelper urlHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterURLtoXML"/> class.
        /// </summary>
        public ConverterURLtoXML()
            : this(new NLogger(), new UrlHelper())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterURLtoXML"/> class.
        /// </summary>
        /// <param name="logger">
        /// Instance of class that implementation <see cref="ICustomeLogger"/>
        /// to logging.
        /// </param>
        /// <param name="urlHelper">
        /// Instance of class that implementation <see cref="IURLHelper"/> to
        /// work with URL.
        /// </param>
        public ConverterURLtoXML(ICustomeLogger logger, IURLHelper urlHelper)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.logger = logger;
            this.urlHelper = urlHelper;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Creates XML tree based on <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The string sequence to transforamtion in xml.</param>
        /// <returns>XDocument.</returns>
        public XDocument Create(IEnumerable<string> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var document = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));
            var rootElemnt = new XElement("urlAddresses");

            foreach (var item in source)
            {
                if (this.urlHelper.IsValid(item))
                {
                    var urlAddressNode = new XElement("urlAddress");

                    this.AddHost(item, urlAddressNode);
                    this.AddUri(item, urlAddressNode);
                    this.AddParameters(item, urlAddressNode);

                    rootElemnt.Add(urlAddressNode);
                }
                else
                {
                    this.logger.Warn($"rows \"{item}\" is not valid.");
                }
            }

            document.Add(rootElemnt);
            return document;
        }

        #endregion

        #region Private methods

        private void AddHost(string source, XElement parent)
        {
            var host = urlHelper.GetHost(source);
            XElement xHost = new XElement("host",
                new XAttribute("name", host));

            parent.Add(xHost);
        }

        private void AddUri(string source, XElement parent)
        {
            IEnumerable<string> setUri = this.urlHelper.GetUri(source);
            if (setUri.Count() > 0)
            {
                XElement uriNode = new XElement("uri");
                uriNode.Add(setUri.Select(t => new XElement("segment", t)));
                parent.Add(uriNode);
            }
        }

        private void AddParameters(string source, XElement parents)
        {
            Dictionary<string, string> parameters = this.urlHelper.GetParameters(source);
            if (parameters.Count > 0)
            {
                XElement parametersNode = new XElement("parameters");
                parametersNode.Add(parameters.Select(
                    t => new XElement("parametr",
                        new XAttribute("value", t.Value),
                        new XAttribute("key", t.Key))));
                parents.Add(parameters);
            }
        }

        #endregion
    }
}
