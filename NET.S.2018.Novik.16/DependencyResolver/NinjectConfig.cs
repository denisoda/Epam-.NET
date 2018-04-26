using ExportToXML.Interface.Interfaces;
using ExportToXML.BussinesModel;
using Ninject;

namespace DependencyResolver
{
    /// <summary>
    /// Settings <see cref="IKernel"/>.
    /// </summary>
    public class NinjectConfig
    {
        public IKernel Kernel { get; private set; }

        public NinjectConfig()
        {
            this.Kernel = new StandardKernel();
            this.Kernel.Bind<IURLHelper>().To<UrlHelper>();
            this.Kernel.Bind<IURLSource>().To<UrlFromTextFile>();
            this.Kernel.Bind<IXMLSaver>().To<XmlSaver>();
            this.Kernel.Bind<IXMLConverter>().To<ConverterURLtoXML>();
        }
    }
}
