using System;
using ExportToXML.Interface.Interfaces;
using NLog;

namespace ExportToXML.BussinesModel
{
    /// <summary>
    /// Provides methods to work with logger.
    /// Wrapper NLog.
    /// </summary>
    class NLogger : ICustomeLogger
    {
        #region Fields

        private Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public methods

        public void Warn(string messsage)
        {
            this.logger.Warn(messsage);
        }

        public void Warn(string message, Exception exception)
        {
            this.logger.Warn(exception, message);
        }

        #endregion

    }
}
