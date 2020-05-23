using System;

namespace PowerPack.Common.Logger
{
    public interface ILoggerClient
    {
        void LogException(Exception ex);

        void LogException(string message);

        void LogWarning(string message);
    }
}
