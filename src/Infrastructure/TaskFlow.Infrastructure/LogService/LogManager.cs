using Serilog;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Infrastructure.LogService
{
    public class LogManager : ILogService
    {

        public void LogInfo(string message)
        {
            Log.Information(message);
        }

        public void LogError(string message, Exception ex)
        {
            Log.Error(message, ex);
        }

        public void LogWarning(string message)
        {
            Log.Warning(message);
        }
    }
}
