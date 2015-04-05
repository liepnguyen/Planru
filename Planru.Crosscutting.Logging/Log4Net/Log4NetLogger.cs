using System;
using log4net;
using log4net.Config;
using Planru.Crosscutting.Logging;

namespace Planru.Crosscutting.Logging.Log4Net
{
    /// <summary>
    /// Logger implementation (Log4Net)
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        private const string MainLogName = "Main";

        /// <summary>
        /// Initializes for a new instance of the <see cref="Log4NetLogger"/> class.
        /// </summary>
        public Log4NetLogger()
        {
            XmlConfigurator.Configure();
        }

        bool ILogger.IsDebugEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsDebugEnabled;
        }

        bool ILogger.IsInfoEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsInfoEnabled;
        }

        bool ILogger.IsWarnEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsWarnEnabled;
        }

        bool ILogger.IsErrorEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsErrorEnabled;
        }

        bool ILogger.IsFatalEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsFatalEnabled;
        }

        public void Debug(string message, Exception exception = null)
        {
            LogManager.GetLogger("Main").Debug(message, exception);
        }

        public void Debug(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Debug(message, exception);
        }

        public void Info(string message, Exception exception = null)
        {
            LogManager.GetLogger(MainLogName).Info(message, exception);
        }

        public void Info(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Info(message, exception);
        }

        public void Warn(string message, Exception exception = null)
        {
            LogManager.GetLogger(MainLogName).Warn(message, exception);
        }

        public void Warn(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Warn(message, exception);
        }

        public void Error(string message, Exception exception = null)
        {
            LogManager.GetLogger(MainLogName).Error(message, exception);
        }

        public void Error(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Error(message, exception);
        }

        public void Fatal(string message, Exception exception = null)
        {
            LogManager.GetLogger(MainLogName).Fatal(message, exception);
        }

        public void Fatal(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Fatal(message, exception);
        }
    }
}
