using Contracts;
using NLog;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        
        public LoggerManager()
        {
        }
        
        /// <summary>
        /// Logs an info message
        /// </summary>
        /// <param name="message">message to be logged</param>
        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Logs a debug message
        /// </summary>
        /// <param name="message">message to be logged</param>
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Logs a warning message
        /// </summary>
        /// <param name="message">message to be logged</param>
        public void LogWarning(string message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">message to be logged</param>
        public void LogError(string message)
        {
            logger.Error(message);
        }
    }
}