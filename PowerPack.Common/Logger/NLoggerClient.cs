using System;
using System.Text;
using NLog;

namespace PowerPack.Common.Logger
{
    public class NLoggerClient : ILoggerClient
    {
        private readonly NLog.Logger _logger;

        public NLoggerClient()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void LogException(Exception ex)
        {
            if (ex != null)
            {
                StringBuilder messageBuilder = new StringBuilder();
                messageBuilder.AppendLine("Message: " + ex.Message);
                if (ex.InnerException != null)
                {
                    messageBuilder.AppendLine("Inner Exception: " + ex.InnerException.Message);
                }
                messageBuilder.AppendLine("Stack Trace: " + ex.StackTrace);
                _logger.Error(messageBuilder.ToString());
            }
        }

        public void LogException(string message)
        {
            _logger.Error(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }


    }
}
