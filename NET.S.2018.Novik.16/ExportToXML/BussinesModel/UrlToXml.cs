using System;
using System.Collections.Generic;
using System.Linq;
using ExportToXML.Interface.Interfaces;
using System.Xml.Linq;

namespace ExportToXML.BussinesModel
{
    public class UrlToXml : IXMLConverter
    {
        #region Private fields

        private ICustomeLogger logger;
        private UrlHelper urlHelper;

        #endregion

        public UrlToXml()
            : this (new ConcreateLogger())
        {
        }

        public UrlToXml(ICustomeLogger logger)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.logger = logger;
            this.urlHelper = new UrlHelper();
        }

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
                    var urlAddressNode = new XElement("urlAddress",
                        new XElement("host",
                        new XAttribute("name", this.urlHelper.GetHost(item))));

                    IEnumerable<string> uri = this.urlHelper.GetUri(item);
                    if (uri.Count() > 0)
                    {
                        urlAddressNode.Add(this.GetUri(uri));
                    }

                    Dictionary<string,string> parameters = this.urlHelper.GetParameters(item);
                    if (parameters.Count > 0)
                    {
                        urlAddressNode.Add(this.GetParameters(parameters));
                    }

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

        private XElement GetHost(string source)
        {
            var host = urlHelper.GetHost(source);
            XElement xHost = new XElement("host",
                new XAttribute("name", host));

            return xHost;
        }

        private XElement GetUri(IEnumerable<string> source)
        {
            XElement uri = new XElement("uri");

            uri.Add(source.Select(t => new XElement("segment", t)));

            return uri;
        }

        private XElement GetParameters(Dictionary<string, string> source)
        {
            XElement parameters = new XElement("parameters");
            parameters.Add(source.Select(t => new XElement("parametr",
                new XAttribute("value", t.Value),
                new XAttribute("key", t.Key))));

            return parameters;

        }

        private bool IsValid(string str)
        {
            return true;
        }
    }
}
