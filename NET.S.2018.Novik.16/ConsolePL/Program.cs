using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using DependencyResolver;
using ExportToXML.Interface.Interfaces;

namespace ConsolePL
{
    class Program
    {
        private IKernel kernel;

        public Program()
        {
            this.kernel = new NinjectConfig().Kernel;
        }

        public void DoWork()
        {
            var source = this.kernel.Get<IURLSource>();
            var xmlConverter = this.kernel.Get<IXMLConverter>();
            var xmlSaver = this.kernel.Get<IXMLSaver>();

            var result = xmlConverter.Create(source.GetRows());
            xmlSaver.Save(result);
        }

        static void Main(string[] args)
        {
            try
            {
                (new Program()).DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
