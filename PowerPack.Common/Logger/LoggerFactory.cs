namespace PowerPack.Common.Logger
{
    public class LoggerFactory
    {
        public static ILoggerClient GetLoggerClient(string loggerClient)
        {
            loggerClient = loggerClient.ToLower();
            if (loggerClient.Equals("nlog"))
            {
                return new NLoggerClient();
            }

            return new NLoggerClient();
        }
    }
}
