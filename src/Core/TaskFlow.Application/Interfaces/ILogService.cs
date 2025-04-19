
namespace TaskFlow.Application.Interfaces
{
    public interface ILogService
    {
        void LogInfo(string message);
        void LogError(string message,Exception ex);
        void LogWarning(string message);
    }
}
