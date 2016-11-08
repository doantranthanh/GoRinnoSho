using System;
using JET.Services.Interfaces.Logger;
using NLog;

namespace JET.Services.Implementations.Logger
{
    public class LoggerService<T> : ILoggerService<T> where T : class
    {

        private readonly NLog.Logger _logger;

        public LoggerService()
        {
            _logger = LogManager.GetLogger(typeof(T).FullName);
        }

        public void Trace(string message, Exception exception = null)
        {
            LogAny(LogLevel.Trace, message, exception);
        }

        public void Debug(string message, Exception exception = null)
        {
            LogAny(LogLevel.Debug, message, exception);
        }

        public void Warn(string message, Exception exception = null)
        {
            LogAny(LogLevel.Warn, message, exception);
        }

        public void Info(string message, Exception exception = null)
        {
            LogAny(LogLevel.Info, message, exception);
        }

        public void Error(string message, Exception exception = null)
        {
            LogAny(LogLevel.Error, message, exception);
        }

        public void Fatal(string message, Exception exception = null)
        {
            LogAny(LogLevel.Fatal, message, exception);
        }

        private void LogAny(LogLevel logLevel, string message, Exception exception)
        {
            if (exception != null)
                _logger.Log(logLevel, message, exception);
            else
                _logger.Log(logLevel, message);

        }


    }
}