using PowerPack.Common.Logger;

namespace PowerPack.Common.Helpers
{
    public static class LoggerClient
    {
        public static ILoggerClient Instance
        {
            get
            {
                return LoggerFactory.GetLoggerClient(PowerPackConfiguration.Instance.DefaultLogger);
            }
        }
    }
}
