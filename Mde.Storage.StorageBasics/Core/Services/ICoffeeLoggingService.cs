using Mde.Storage.StorageBasics.Core.Models;

namespace Mde.Storage.StorageBasics.Core.Services
{
    public interface ICoffeeLoggingService
    {
        void Log(Coffee coffee);
        IEnumerable<LogEntry> GetLogs();
        void Clear();
    }
}
