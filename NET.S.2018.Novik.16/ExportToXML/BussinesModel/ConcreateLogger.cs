using System;
using ExportToXML.Interface.Interfaces;
using NLog;

namespace ExportToXML.BussinesModel
{
    class ConcreateLogger : ICustomeLogger
    {
        #region Fields

        private Logger Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public methods

        public void Warn(string messsage)
        {
            Log.Warn(messsage);
        }

        public void Warn(string message, Exception exception)
        {
            Log.Warn(exception, message);
        }

        #endregion

    }
}
