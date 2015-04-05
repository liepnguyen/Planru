using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Logging.NullLogger
{
    /// <summary>
    /// Null object pattern logger implementation (logs nothing)
    /// </summary>
    public class NullLogger : ILogger
    {
        public bool IsDebugEnabled(string logType)
        {
            return false;
        }

        public bool IsInfoEnabled(string logType)
        {
            return false;
        }

        public bool IsWarnEnabled(string logType)
        {
            return false;
        }

        public bool IsErrorEnabled(string logType)
        {
            return false;
        }

        public bool IsFatalEnabled(string logType)
        {
            return false;
        }

        public void Debug(string message, Exception exception)
        {
        }

        public void Debug(string logType, string message, Exception exception)
        {
        }

        public void Info(string message, Exception exception)
        {
        }

        public void Info(string logType, string message, Exception exception)
        {
        }

        public void Warn(string message, Exception exception)
        {
        }

        public void Warn(string logType, string message, Exception exception)
        {
        }

        public void Error(string message, Exception exception)
        {
        }

        public void Error(string logType, string message, Exception exception)
        {
        }

        public void Fatal(string message, Exception exception)
        {
        }

        public void Fatal(string logType, string message, Exception exception)
        {
        }
    }
}
