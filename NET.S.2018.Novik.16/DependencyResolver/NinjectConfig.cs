using ExportToXML.Interface.Interfaces;
using ExportToXML.BussinesModel;
using Ninject;

namespace DependencyResolver
{
    public class NinjectConfig
    {
        public IKernel Kernel { get; private set; }

        public NinjectConfig()
        {
            this.Kernel = new StandardKernel();
            this.Kernel.Bind<IURLHelper>().To<UrlHelper>();
            this.Kernel.Bind<IURLSource>().To<UrlsSource>();
            this.Kernel.Bind<IXMLSaver>().To<XmlSaver>();
            this.Kernel.Bind<IXMLConverter>().To<UrlToXml>();
        }
    }
}
