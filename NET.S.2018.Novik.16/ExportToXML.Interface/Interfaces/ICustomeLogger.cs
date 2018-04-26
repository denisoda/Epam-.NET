using System;

namespace ExportToXML.Interface.Interfaces
{
    public interface ICustomeLogger
    {
        void Warn(string messsage);

        void Warn(string message, Exception exception);
    }
}
