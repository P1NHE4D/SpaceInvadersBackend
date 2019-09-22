namespace Contracts
{
    public interface ILoggerManager
    {
        /**
         * Log an info message
         */
        void LogInfo(string message);
        
        /**
         * Log a debug message
         */
        void LogDebug(string message);
        
        /**
         * Log a warning message
         */
        void LogWarning(string message);
        
        /**
         * Log an error message
         */
        void LogError(string message);
    }
}