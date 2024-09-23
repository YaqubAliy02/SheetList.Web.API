namespace SheetList.Web.API.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogDebug(string message);
        void LogError(Exception exception);
        void LogWarning(string message);
        void LogTrace(string message);
        void LogCritical(Exception exception);
    }
}